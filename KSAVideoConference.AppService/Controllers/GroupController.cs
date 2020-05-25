using AutoMapper;
using KSAVideoConference.AppService.Hubs;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "Group")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IHubContext<AppHub, IAppHub> _hubContext;

        public GroupController(ILogger<GroupController> logger, DataContext dataContext,
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
        /// Post : Create Group
        /// </summary>
        [HttpPost]
        [Route("CreateGroup")]
        public async Task<GroupModel> CreateGroup([FromQuery]Guid Token, [FromForm]IGroupModel Group)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                if (UserDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnAuth);
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnActive, UserDB.Fk_Language);
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.InCompleteData, UserDB.Fk_Language);
                }
                else
                {
                    Group GroupDB = new Group();

                    _Mapper.Map(Group, GroupDB);

                    GroupDB.SessionId = await OpenTokManager.CreateSessionId();
                    GroupDB.Fk_Creator = UserDB.Id;

                    _UnitOfWork.GroupRepository.CreateEntityAsync(GroupDB);
                    await _UnitOfWork.GroupRepository.SaveAsync();

                    await _UnitOfWork.GroupRepository.UploudFile(GroupDB, Group.UploudFile);

                    await _hubContext.Groups.AddToGroupAsync(GroupDB.Fk_Creator.ToString(), GroupDB.Id.ToString());
                    await _hubContext.Clients.Group(GroupDB.Id.ToString()).Send($"{UserDB.FullName} لقد انضم إلى المجموعة {GroupDB.Name}.");

                    returnData = await _UnitOfWork.GroupRepository.GetGroupProfile(GroupDB.Id, UserDB.Id);

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Status.ErrorMessage = _UnitOfWork.AppStaticMessageRepository.Encode(Status.ErrorMessage);

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return returnData;
        }

        /// <summary>
        /// Patch : Update Group
        /// </summary>
        [HttpPatch]
        [Route(nameof(UpdateGroup))]
        public async Task<GroupModel> UpdateGroup([FromQuery]Guid Token, [FromForm]IGroupModel Group)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsync(Group.Id);

                if (UserDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnAuth);
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnActive, UserDB.Fk_Language);
                }
                else if (GroupDB.Fk_Creator != UserDB.Id)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.NotOwner, UserDB.Fk_Language);
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.InCompleteData, UserDB.Fk_Language);
                }
                else
                {
                    _Mapper.Map(Group, GroupDB);
                    _UnitOfWork.GroupRepository.UpdateEntity(GroupDB);
                    await _UnitOfWork.GroupRepository.SaveAsync();

                    await _UnitOfWork.GroupRepository.UploudFile(GroupDB, Group.UploudFile);

                    if (!GroupDB.IsActive)
                    {
                        await _hubContext.Clients.Group(GroupDB.Id.ToString()).Send($"{UserDB.FullName} لقد تم ايقاف المجموعه {GroupDB.Name}.");
                    }
                    else
                    {
                        await _hubContext.Clients.Group(GroupDB.Id.ToString()).Send($"{UserDB.FullName} لقد تم تحديث بيانات المجموعه {GroupDB.Name}.");
                    }

                    returnData = await _UnitOfWork.GroupRepository.GetGroupProfile(GroupDB.Id, UserDB.Id);

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Status.ErrorMessage = _UnitOfWork.AppStaticMessageRepository.Encode(Status.ErrorMessage);
            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return returnData;
        }


        /// <summary>
        /// Get : Groups
        /// </summary>
        [HttpGet]
        [Route(nameof(GetGroups))]
        public async Task<PagedList<GroupModel>> GetGroups([FromQuery] Paging paging, [FromQuery]Guid Token,
            [FromQuery]string Name, [FromQuery]bool MyGroups = false, [FromQuery]bool MyOwnGroups = false,
            [FromQuery]bool IsActive = true)
        {
            string ActionName = nameof(GetGroups);
            List<GroupModel> returnData = new List<GroupModel>();
            PagedList<GroupModel> PagedData = PagedList<GroupModel>.Create(returnData, paging.PageNumber, paging.PageSize);
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                if (UserDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnAuth);
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnActive, UserDB.Fk_Language);
                }
                else
                {
                    List<Group> Data = await _DBContext.Group.Where(a => a.IsActive == IsActive)
                                                             .Where(a => string.IsNullOrEmpty(Name) ? true : a.Name.Contains(Name))
                                                             .Where(a => MyOwnGroups == false ? true : a.Fk_Creator == UserDB.Id
                                                                         || MyGroups == false ? true : a.GroupMembers.Any(b => b.Fk_User == UserDB.Id))
                                                             .Include(a => a.GroupMembers)
                                                             .ThenInclude(a => a.User)
                                                             .ToListAsync();

                    IEnumerable<Group> OrderData = OrderBy<Group>.OrderData(Data, paging.OrderBy);

                    foreach (Group item in OrderData)
                    {
                        GroupModel item2 = new GroupModel();

                        _Mapper.Map(item, item2);

                        item2.SummaryMemberNames = "";

                        List<string> Names = item.GroupMembers.Select(a => a.User.FullName).ToList();
                        foreach (string item3 in Names)
                        {
                            item2.SummaryMemberNames += item3 + ", ";
                        }

                        returnData.Add(item2);
                    }

                    PagedData = PagedList<GroupModel>.Create(returnData, paging.PageNumber, paging.PageSize);

                    if (PagedData.Any())
                    {
                        if (MyOwnGroups)
                        {
                            PagedData.ForEach(a => { a.IsJoin = true; a.IsOwner = true; });
                        }
                        else if (MyGroups)
                        {
                            PagedData.ForEach(a => a.IsJoin = true);
                        }
                        else
                        {
                            foreach (GroupModel item in PagedData)
                            {
                                if (Data.Any(a => a.Id == item.Id && a.Fk_Creator == UserDB.Id))
                                {
                                    item.IsJoin = true;
                                    item.IsOwner = true;
                                }
                                else if (Data.Any(a => a.Id == item.Id && a.GroupMembers.Any(b => b.Fk_User == UserDB.Id)))
                                {
                                    item.IsJoin = true;
                                }
                            }
                        }
                    }

                    PaginationMetaData<GroupModel> PaginationMetaData = new PaginationMetaData<GroupModel>(PagedData)
                    {
                        PrevoisPageLink = (PagedData.HasPrevious) ? Url.Link(ActionName, new { paging.OrderBy, pageNumber = (paging.PageNumber - 1), paging.PageSize }) : null,
                        NextPageLink = (PagedData.HasNext) ? Url.Link(ActionName, new { paging.OrderBy, pageNumber = (paging.PageNumber + 1), paging.PageSize }) : null
                    };

                    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData).Replace(@"\u0026", "&"));

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Status.ErrorMessage = _UnitOfWork.AppStaticMessageRepository.Encode(Status.ErrorMessage);
            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return PagedData;
        }

        /// <summary>
        /// Get : Group Profile
        /// </summary>
        [HttpGet]
        [Route("GetGroupProfile")]
        public async Task<GroupModel> GetGroupProfile([FromQuery]Guid Token, [FromQuery]int Id)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(Id);

                if (UserDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnAuth);
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnActive, UserDB.Fk_Language);
                }
                else if (!GroupDB.IsActive)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.NotActiveGroup, UserDB.Fk_Language);
                }
                else if (!(GroupDB.Fk_Creator == UserDB.Id || GroupDB.GroupMembers.Any(a => a.Fk_User == UserDB.Id)))
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.JoinGroup, UserDB.Fk_Language);
                }
                else
                {
                    returnData = await _UnitOfWork.GroupRepository.GetGroupProfile(GroupDB.Id, UserDB.Id);

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Status.ErrorMessage = _UnitOfWork.AppStaticMessageRepository.Encode(Status.ErrorMessage);
            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return returnData;
        }
    }
}