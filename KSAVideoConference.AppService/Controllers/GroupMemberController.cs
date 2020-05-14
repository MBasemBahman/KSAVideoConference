using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public GroupMemberController(ILogger<GroupMemberController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
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
                    }

                    Status = new Status(true);

                    _Mapper.Map(GroupDB, returnData);

                    returnData.IsJoin = true;

                    if (GroupDB.Fk_Creator == UserDB.Id)
                    {
                        returnData.IsOwner = true;
                    }

                    returnData.Creator = new UserModel();
                    _Mapper.Map(GroupDB.Creator, returnData.Creator);

                    returnData.GroupMembers = new List<GroupMemberModel>();
                    _Mapper.Map(GroupDB.GroupMembers, returnData.GroupMembers);

                    returnData.GroupMessages = new List<GroupMessageModel>();
                    _Mapper.Map(GroupDB.GroupMembers, returnData.GroupMembers);
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