using AutoMapper;
using KSAVideoConference.AppService.Hubs;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "GroupMessage")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class GroupMessageController : ControllerBase
    {
        private readonly ILogger<GroupMessageController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IHubContext<AppHub, IAppHub> _hubContext;


        public GroupMessageController(ILogger<GroupMessageController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper,
                            IHubContext<AppHub, IAppHub> hubContext)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Post : Send Message
        /// </summary>
        [HttpPost]
        [Route("SendMessage")]
        public async Task<GroupMessageModel> SendMessage([FromQuery]Guid Token, [FromForm]IGroupMessageModel GroupMessage)
        {
            GroupMessageModel returnData = new GroupMessageModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(GroupMessage.Fk_Group);

                if (UserDB == null)
                {
                    Status.ErrorMessage = "لم يتم التعرف عليك";
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = "لقد تم وقف حسابك على التطبيق";
                }
                else if (!GroupDB.IsActive)
                {
                    Status.ErrorMessage = "المجموعه غير نشطه";
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = "البيانات غير مكتمله";
                }
                else
                {
                    GroupMessage GroupMessageDB = new GroupMessage();
                    _Mapper.Map(GroupMessage, GroupMessageDB);

                    GroupMessageDB.Fk_User = UserDB.Id;
                    GroupDB.GroupMessages.Add(GroupMessageDB);

                    _UnitOfWork.GroupRepository.UpdateEntity(GroupDB);
                    _UnitOfWork.GroupRepository.Save();

                    await UploudFile(GroupMessageDB, GroupMessage.UploudFile);

                    await _hubContext.Clients.Group(GroupMessageDB.Fk_Group.ToString()).Send($"{GroupMessageDB.Message}");

                    GroupMessageDB = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(GroupMessageDB.Id);

                    _Mapper.Map(GroupMessageDB, returnData);

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));

            return returnData;
        }


        /// <summary>
        /// Delete : Delete Message
        /// </summary>
        [HttpDelete]
        [Route("DeleteMessage")]
        public async Task<bool> DeleteMessage([FromQuery]Guid Token, [FromBody]IGroupMessageModel GroupMessage)
        {
            bool returnData = new bool();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                GroupMessage GroupMessageDB = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(GroupMessage.Id);

                if (UserDB == null)
                {
                    Status.ErrorMessage = "لم يتم التعرف عليك";
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = "لقد تم وقف حسابك على التطبيق";
                }
                else
                {
                    if (GroupMessageDB.Attachment != null)
                    {
                        Attachment Attachment = GroupMessageDB.Attachment;
                        if (!string.IsNullOrEmpty(Attachment.AttachmentURL))
                        {
                            ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);
                            ImgManager.DeleteImage(Attachment.AttachmentURL, AppMainData.DomainName);
                        }
                    }

                    _UnitOfWork.GroupMessageRepository.DeleteEntity(GroupMessageDB);
                    _UnitOfWork.GroupMessageRepository.Save();

                    returnData = true;
                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));

            return returnData;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<GroupMessage> UploudFile(GroupMessage GroupMessage, IFormFile File)
        {
            if (File != null)
            {
                ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                Attachment Attachment = new Attachment
                {
                    Name = File.FileName,
                    Type = File.ContentType,
                    Length = File.Length
                };

                _UnitOfWork.AttachmentRepository.CreateEntityAsync(Attachment);
                await _UnitOfWork.AttachmentRepository.SaveAsync();

                string FileURL = await ImgManager.UploudImageAsync(AppMainData.DomainName, Attachment.Id.ToString(), File, "Uploud\\Attachment");

                if (!string.IsNullOrEmpty(FileURL))
                {
                    Attachment.AttachmentURL = FileURL;
                    GroupMessage.Fk_Attachment = Attachment.Id;
                    _UnitOfWork.AttachmentRepository.UpdateEntity(Attachment);
                    _UnitOfWork.GroupMessageRepository.UpdateEntity(GroupMessage);
                    await _UnitOfWork.AttachmentRepository.SaveAsync();
                }
            }
            return GroupMessage;
        }
    }
}