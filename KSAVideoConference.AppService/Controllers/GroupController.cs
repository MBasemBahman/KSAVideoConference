using AutoMapper;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace KSAVideoConference.AppService.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
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

        public GroupController(ILogger<GroupController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        /// <summary>
        /// Post : Create Group
        /// </summary>
        [HttpPost]
        [Route("CreateGroup")]
        public async Task<GroupModel> CreateGroup([FromQuery]Guid Token, [FromBody]IGroupModel Group)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                if (UserDB == null)
                {
                    Status.ErrorMessage = "لم يتم التعرف عليك";
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = "لقد تم وقف حسابك على التطبيق";
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = "البيانات غير مكتمله";
                }
                else
                {
                    Group GroupDB = new Group();

                    _Mapper.Map(Group, GroupDB);

                    GroupDB.SessionId = OpenTokManager.CreateSessionId();
                    GroupDB.Fk_Creator = UserDB.Id;

                    _UnitOfWork.GroupRepository.CreateEntityAsync(GroupDB);
                    await _UnitOfWork.GroupRepository.SaveAsync();

                    Status = new Status(true);

                    _Mapper.Map(GroupDB, returnData);
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
        /// Patch : Update Group
        /// </summary>
        [HttpPatch]
        [Route("UpdateGroup")]
        public async Task<GroupModel> UpdateGroup([FromQuery]Guid Token, [FromBody]IGroupModel Group)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsync(Group.Id);

                if (UserDB == null)
                {
                    Status.ErrorMessage = "لم يتم التعرف عليك";
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = "لقد تم وقف حسابك على التطبيق";
                }
                else if (GroupDB.Fk_Creator != UserDB.Id)
                {
                    Status.ErrorMessage = "ليس لديك الصلاحيه للتعديل على المجموعه";
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = "البيانات غير مكتمله";
                }
                else
                {
                    _Mapper.Map(Group, GroupDB);

                    _UnitOfWork.GroupRepository.UpdateEntity(GroupDB);
                    await _UnitOfWork.GroupRepository.SaveAsync();

                    Status = new Status(true);

                    _Mapper.Map(GroupDB, returnData);
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
        /// Get : Groups
        /// </summary>
        [HttpGet]
        [Route("GetGroups")]
        public async Task<PagedList<GroupModel>> GetGroups([FromQuery] Paging paging, [FromQuery]Guid Token,
            [FromQuery]string Name, [FromQuery]bool MyGroups = false, [FromQuery]bool MyOwnGroups = false,
            [FromQuery]bool IsActive = true)
        {
            string ActionName = ControllerContext.RouteData.Values["action"].ToString();
            List<GroupModel> returnData = new List<GroupModel>();
            PagedList<GroupModel> PagedData = PagedList<GroupModel>.Create(returnData, paging.PageNumber, paging.PageSize);
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
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
                    List<Group> Data = await _DBContext.Group.Where(a => a.IsActive == IsActive)
                                                             .Where(a => string.IsNullOrEmpty(Name) ? true : a.Name.Contains(Name))
                                                             .Where(a => MyGroups == false ? true : a.GroupMembers.Any(b => b.IsActive == true && b.Fk_User == UserDB.Id))
                                                             .Where(a => MyOwnGroups == false ? true : a.Fk_Creator == UserDB.Id)
                                                             .Include(a => a.GroupMembers)
                                                             .ToListAsync();

                    IEnumerable<Group> OrderData = OrderBy<Group>.OrderData(Data, paging.OrderBy);

                    _Mapper.Map(OrderData, returnData);

                    PagedData = PagedList<GroupModel>.Create(returnData, paging.PageNumber, paging.PageSize);

                    if (PagedData.Any())
                    {
                        if (MyGroups)
                        {
                            PagedData.ForEach(a => a.IsJoin = true);
                        }
                        else if (MyOwnGroups)
                        {
                            PagedData.ForEach(a => { a.IsJoin = true; a.IsOwner = true; });
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
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(Id);

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
                else if (!(GroupDB.Fk_Creator == UserDB.Id || GroupDB.GroupMembers.Any(a => a.Fk_User == UserDB.Id && a.IsActive == true)))
                {
                    Status.ErrorMessage = "يجب الانضمام الى المجموعه";
                }
                else
                {
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