using AutoMapper;
using KSAVideoConference.CommonBL;
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
using System.Text.Json;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "App")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public AppController(ILogger<AppController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        /// <summary>
        /// Get : All Member Types 
        /// </summary>
        [HttpGet]
        [Route(nameof(GetMemberTypes))]
        public async Task<PagedList<MemberTypeModel>> GetMemberTypes([FromQuery] Paging paging, [FromQuery] Guid Token)
        {
            string ActionName = nameof(GetMemberTypes);
            List<MemberTypeModel> returnData = new List<MemberTypeModel>();
            PagedList<MemberTypeModel> PagedData = PagedList<MemberTypeModel>.Create(returnData, paging.PageNumber, paging.PageSize);
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
                    List<MemberType> Data = await _UnitOfWork.MemberTypeRepository.GetAllAsync();

                    IEnumerable<MemberType> OrderData = OrderBy<MemberType>.OrderData(Data, paging.OrderBy);

                    _Mapper.Map(OrderData, returnData);

                    PagedData = PagedList<MemberTypeModel>.Create(returnData, paging.PageNumber, paging.PageSize);

                    PaginationMetaData<MemberTypeModel> PaginationMetaData = new PaginationMetaData<MemberTypeModel>(PagedData)
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
        /// Post : Generate Conference Token
        /// </summary>
        [HttpPost]
        [Route(nameof(GenerateToken))]
        public async Task<string> GenerateToken([FromQuery] Guid Token, [FromQuery] int Fk_Group)
        {
            string returnData = "";
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
                    Group Group = await _UnitOfWork.GroupRepository.GetByIDAsync(Fk_Group);

                    if (Group != null && !string.IsNullOrEmpty(Group.SessionId))
                    {
                        returnData = OpenTokManager.GenerateToken(Group.SessionId);

                        Status = new Status(true);

                        NotificationManager.Notification = new FirebaseNotificationModel
                        {
                            NotificationType = new KeyValuePair<int, string>((int)NotificationTypeEnum.Group, Enum.GetName(typeof(NotificationTypeEnum), (int)NotificationTypeEnum.Group)),
                            TargetId = Group.Id,
                            MessageHeading = "انضمام عضو جديد",
                            MessageContent = $"لقد انضم {UserDB.FullName} الى المحادثه",
                            Topic = Enum.GetName(typeof(NotificationTypeEnum), (int)NotificationTypeEnum.Group)
                        };

                        var Members = (await _UnitOfWork.UserRepository.GetAllAsync(a => a.GroupMembers.Any(b => b.Fk_Group == Fk_Group) || a.Groups.Any(b => b.Id == Fk_Group))).Select(a => a.NotificationToken).ToList();

                        if (Members.Any())
                        {
                            Members.Remove(UserDB.NotificationToken);

                            NotificationManager.Notification.RegistrationTokens = Members;

                            await NotificationManager.SendMulticast(NotificationManager.CreateMulticastMessage(NotificationManager.Notification));
                        }
                    }
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
        /// Post : Test Notification
        /// </summary>
        [HttpPost]
        [Route(nameof(TestNotification))]
        public async Task<string> TestNotification([FromQuery] Guid Token, [FromQuery] NotificationModelTest Notification)
        {
            string returnData = "";
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
                    Status = new Status(true);

                    NotificationManager.Notification = new FirebaseNotificationModel
                    {
                        NotificationType = new KeyValuePair<int, string>((int)NotificationTypeEnum.Group, Enum.GetName(typeof(NotificationTypeEnum), (int)NotificationTypeEnum.Group)),
                        TargetId = 1,
                        MessageHeading = Notification.MessageHeading,
                        MessageContent = Notification.MessageContent,
                        Topic = Enum.GetName(typeof(NotificationTypeEnum), (int)NotificationTypeEnum.Group)
                    };

                    NotificationManager.Notification.RegistrationTokens = new List<string>
                    {
                        Notification.RegistrationToken
                    };

                    await NotificationManager.SendMulticast(NotificationManager.CreateMulticastMessage(NotificationManager.Notification));
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