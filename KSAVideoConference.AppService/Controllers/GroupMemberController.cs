using AutoMapper;
using KSAVideoConference.AppService.Hubs;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "GroupMember")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class GroupMemberController : ControllerBase
    {
        private readonly ILogger<GroupMemberController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IHubContext<AppHub, IAppHub> _hubContext;

        public GroupMemberController(ILogger<GroupMemberController> logger, DataContext dataContext,
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
        /// Post : Join Group
        /// </summary>
        [HttpPost]
        [Route("JoinGroup")]
        public async Task<GroupModel> JoinGroup([FromQuery]Guid Token, [FromBody]IGroupMemberModel GroupMember)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(GroupMember.Fk_Group);

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
                    if (GroupDB.Fk_Creator != UserDB.Id)
                    {
                        GroupMember GroupMemberDB = GroupDB.GroupMembers.FirstOrDefault(a => a.Fk_User == UserDB.Id);

                        if (GroupMemberDB != null)
                        {
                            GroupDB.GroupMembers.Remove(GroupMemberDB);
                            GroupMemberDB.IsActive = true;
                        }
                        else
                        {
                            GroupMemberDB = new GroupMember();
                            _Mapper.Map(GroupMember, GroupMemberDB);
                        }

                        GroupMemberDB.Fk_User = UserDB.Id;
                        GroupDB.GroupMembers.Add(GroupMemberDB);

                        _UnitOfWork.GroupRepository.UpdateEntity(GroupDB);
                        _UnitOfWork.GroupRepository.Save();

                        await _hubContext.Groups.AddToGroupAsync(UserDB.Id.ToString(), GroupDB.Id.ToString());
                        await _hubContext.Clients.Group(GroupDB.Id.ToString()).Send($"{UserDB.FullName} لقد انضم إلى المجموعة {GroupDB.Name}.");
                    }

                    returnData = await _UnitOfWork.GroupRepository.GetGroupProfile(GroupDB.Id, UserDB.Id);

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
        /// Patch : Exit Group
        /// </summary>
        [HttpPatch]
        [Route("ExitGroup")]
        public async Task<bool> ExitGroup([FromQuery]Guid Token, [FromBody]IGroupMemberModel GroupMember)
        {
            bool returnData = new bool();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                GroupMember GroupMemberDB = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(GroupMember.Id);

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
                    if (GroupMemberDB.Group.Fk_Creator != UserDB.Id)
                    {
                        GroupMemberDB.IsActive = false;
                        _UnitOfWork.GroupMemberRepository.UpdateEntity(GroupMemberDB);
                        await _UnitOfWork.GroupMemberRepository.SaveAsync();

                        await _hubContext.Groups.RemoveFromGroupAsync(UserDB.Id.ToString(), GroupMemberDB.Fk_Group.ToString());
                        await _hubContext.Clients.Group(GroupMemberDB.Fk_Group.ToString()).Send($"{UserDB.FullName} غادر المجموعة {GroupMemberDB.Group.Name}.");

                        returnData = true;
                        Status = new Status(true);
                    }
                    else
                    {
                        Status.ErrorMessage = "لا يمكنك من الخروج لأنك مالك الجروب";
                    }
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));

            return returnData;
        }
    }
}