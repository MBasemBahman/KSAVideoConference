using AutoMapper;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Produces("application/json")]
    [Consumes("application/json")]
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
        [HttpPost, DisableRequestSizeLimit]
        [Route(nameof(CreateAccount))]
        public async Task<UserModel> CreateAccount([FromBody]IUserModel User)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();
            try
            {
                if (await _UnitOfWork.UserRepository.CheckExisting(a => a.Phone.Contains(User.Phone)))
                {
                    Status.ErrorMessage = "رقم الجوال مسجل لدينا بالفعل";
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = "البيانات غير مكتمله";
                }
                else
                {
                    User UserDB = new User();

                    _Mapper.Map(User, UserDB);

                    _UnitOfWork.UserRepository.CreateEntityAsync(UserDB);
                    await _UnitOfWork.UserRepository.SaveAsync();

                    IFormFile files = HttpContext.Request.Form.Files["ImageFile"];
                    if (files != null)
                    {
                        ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                        string ImageURL = await ImgManager.UploudImageAsync(AppMainData.DomainName, UserDB.Id.ToString(), files, "Uploud\\User");

                        if (!string.IsNullOrEmpty(ImageURL))
                        {
                            if (!string.IsNullOrEmpty(UserDB.ImageURL))
                            {
                                ImgManager.DeleteImage(UserDB.ImageURL, AppMainData.DomainName);
                            }
                            UserDB.ImageURL = ImageURL;
                            _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                            await _UnitOfWork.UserRepository.SaveAsync();
                        }
                    }

                    Status = new Status(true);

                    _Mapper.Map(UserDB, returnData);
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
        /// Patch : Update User Account Profile
        /// </summary>
        [HttpPatch, DisableRequestSizeLimit]
        [Route(nameof(UpdateAccount))]
        public async Task<UserModel> UpdateAccount([FromQuery]Guid Token, [FromBody]IUserModel User)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                if (UserDB == null)
                {
                    Status.ErrorMessage = "لم يتم التعرف عليك";
                }
                else if (await _UnitOfWork.UserRepository.CheckExisting(a => UserDB.Phone != User.Phone && a.Phone.Contains(User.Phone) && a.Id != UserDB.Id))
                {
                    Status.ErrorMessage = "رقم الجوال مسجل لدينا بالفعل";
                }
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = "البيانات غير مكتمله";
                }
                else
                {
                    _Mapper.Map(User, UserDB);

                    _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                    await _UnitOfWork.UserRepository.SaveAsync();

                    IFormFile files = HttpContext.Request.Form.Files["ImageFile"];
                    if (files != null)
                    {
                        ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                        string ImageURL = await ImgManager.UploudImageAsync(AppMainData.DomainName, UserDB.Id.ToString(), files, "Uploud\\User");

                        if (!string.IsNullOrEmpty(ImageURL))
                        {
                            if (!string.IsNullOrEmpty(UserDB.ImageURL))
                            {
                                ImgManager.DeleteImage(UserDB.ImageURL, AppMainData.DomainName);
                            }
                            UserDB.ImageURL = ImageURL;
                            _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                            await _UnitOfWork.UserRepository.SaveAsync();
                        }
                    }

                    Status = new Status(true);

                    _Mapper.Map(UserDB, returnData);
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
        /// Post : Login With Phone
        /// </summary>
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<UserModel> Login([FromBody]IUserModel User)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByPhoneAsync(User.Phone);
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
                    Status = new Status(true);

                    _Mapper.Map(UserDB, returnData);
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
        /// Get : Users
        /// </summary>
        [HttpGet]
        [Route(nameof(GetUsers))]
        public async Task<PagedList<UserModel>> GetUsers([FromQuery] Paging paging, [FromQuery]Guid Token, [FromQuery]string phone,
            [FromQuery]bool MyOwnContact = false)
        {
            string ActionName = nameof(GetUsers);
            List<UserModel> returnData = new List<UserModel>();
            PagedList<UserModel> PagedData = PagedList<UserModel>.Create(returnData, paging.PageNumber, paging.PageSize);
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
                    phone = phone.Trim();

                    List<User> Data = await _DBContext.User.Where(a => a.IsActive == true)
                                                            .Where(a => a.Phone.Contains(phone))
                                                            .Where(a => MyOwnContact == false ? true : a.MyUserContacts.Any(a => a.Fk_User == UserDB.Id))
                                                            .ToListAsync();

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

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return PagedData;
        }
    }
}