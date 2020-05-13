using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace KSAVideoConference.AppService.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
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

        public GroupMessageController(ILogger<GroupMessageController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        /// <summary>
        /// Post : Send Message
        /// </summary>
        [HttpPost]
        [Route("SendMessage")]
        public async Task<GroupMessageModel> SendMessage([FromQuery]Guid Token, [FromBody]IGroupMessageModel GroupMessage)
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

                    Status = new Status(true);

                    _Mapper.Map(GroupMessageDB, returnData);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

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

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return returnData;
        }
    }
}