using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "User")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;


        public UserController(ILogger<UserController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        /// <summary>
        /// Post : Create User Account
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateAccount))]
        public async Task<UserModel> CreateAccount([FromForm] IUserModel User)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();
            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                if (await _UnitOfWork.UserRepository.GetByPhoneAsync(User.Phone) != null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.DuplicateNumber);
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.InCompleteData);
                }
                else
                {
                    User UserDB = new User();

                    _Mapper.Map(User, UserDB);

                    _UnitOfWork.UserRepository.CreateEntityAsync(UserDB);
                    await _UnitOfWork.UserRepository.SaveAsync();

                    await _UnitOfWork.UserRepository.UploudFile(UserDB, User.UploudFile);

                    returnData = await _UnitOfWork.UserRepository.GetUserProfile(UserDB.Id);

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
        /// Patch : Update User Account Profile
        /// </summary>
        [HttpPatch]
        [Route(nameof(UpdateAccount))]
        public async Task<UserModel> UpdateAccount([FromQuery] Guid Token, [FromForm] IUserModel User)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                if (UserDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnAuth);
                }
                else if (await _UnitOfWork.UserRepository.GetByPhoneAsync(UserDB.Phone, UserDB.Id) != null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.DuplicateNumber, UserDB.Fk_Language);
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.InCompleteData, UserDB.Fk_Language);
                }
                else
                {
                    _Mapper.Map(User, UserDB);

                    _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                    await _UnitOfWork.UserRepository.SaveAsync();

                    await _UnitOfWork.UserRepository.UploudFile(UserDB, User.UploudFile);

                    returnData = await _UnitOfWork.UserRepository.GetUserProfile(UserDB.Id);

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
        /// Post : Login With Phone
        /// </summary>
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<UserModel> Login([FromForm] string Phone, int Fk_Language)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByPhoneAsync(Phone);
                if (UserDB != null)
                {
                    UserDB.Fk_Language = Fk_Language;
                }
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
                    _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                    await _UnitOfWork.UserRepository.SaveAsync();

                    returnData = await _UnitOfWork.UserRepository.GetUserProfile(UserDB.Id);
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
        /// Get : Users
        /// </summary>
        [HttpGet]
        [Route(nameof(GetUsers))]
        public async Task<PagedList<UserModel>> GetUsers([FromQuery] Paging paging, [FromQuery] Guid Token, [FromQuery] string phone,
            [FromQuery] bool MyOwnContact = false, [FromQuery] int Fk_Group = 0, [FromQuery] bool InGroup = false)
        {
            string ActionName = nameof(GetUsers);
            List<UserModel> returnData = new List<UserModel>();
            PagedList<UserModel> PagedData = PagedList<UserModel>.Create(returnData, paging.PageNumber, paging.PageSize);
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
                    if (!string.IsNullOrEmpty(phone))
                    {
                        phone = phone.Trim();
                    }

                    List<User> Data = await _DBContext.User.Where(a => a.IsActive == true)
                                                           .Where(a => a.Id != UserDB.Id)
                                                           .Where(a => string.IsNullOrEmpty(phone) || a.Phone.Contains(phone))
                                                           .Where(a => MyOwnContact == false || a.MeInUserContacts.Any(b => b.Fk_User == UserDB.Id))
                                                           .ToListAsync();

                    if (Fk_Group > 0 && Data.Any())
                    {
                        List<User> GroupMembers = await _DBContext.GroupMember.Where(a => a.Fk_Group == Fk_Group)
                                                                       .Select(a => a.User)
                                                                       .ToListAsync();

                        if (InGroup == false)
                        {
                            Data = Data.Except(GroupMembers).ToList();
                        }
                        else
                        {
                            Data = Data.Where(a => GroupMembers.Any(b => b.Id == a.Id)).ToList();
                        }
                    }

                    IEnumerable<User> OrderData = OrderBy<User>.OrderData(Data, paging.OrderBy);

                    _Mapper.Map(OrderData, returnData);

                    PagedData = PagedList<UserModel>.Create(returnData, paging.PageNumber, paging.PageSize);

                    PaginationMetaData<UserModel> PaginationMetaData = new PaginationMetaData<UserModel>(PagedData)
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
    }
}