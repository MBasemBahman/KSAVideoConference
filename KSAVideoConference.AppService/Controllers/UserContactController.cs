using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "UserContact")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class UserContactController : ControllerBase
    {
        private readonly ILogger<UserContactController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public UserContactController(ILogger<UserContactController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        /// <summary>
        /// Post : Add Contact
        /// </summary>
        [HttpPost]
        [Route("AddContact")]
        public async Task<UserModel> AddContact([FromQuery]Guid Token, [FromBody]IUserContactModel UserContact)
        {
            UserModel returnData = new UserModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                User ContactDB = await _UnitOfWork.UserRepository.GetByIDAsyncIclude(UserContact.Fk_Contact);

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
                    UserContact UserContactDB = new UserContact();
                    _Mapper.Map(UserContact, UserContactDB);

                    UserDB.MyUserContacts.Add(UserContactDB);

                    _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                    _UnitOfWork.UserRepository.Save();

                    returnData = await _UnitOfWork.UserRepository.GetUserProfile(UserContactDB.Fk_Contact);

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
        /// Delete : Delete Contact
        /// </summary>
        [HttpDelete]
        [Route("DeleteContact")]
        public async Task<bool> DeleteContact([FromQuery]Guid Token, [FromBody]IUserContactModel UserContact)
        {
            bool returnData = new bool();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                UserContact UserContactDB = await _UnitOfWork.UserContactRepository.GetByIDAsyncIclude(UserContact.Id);

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
                    _UnitOfWork.UserContactRepository.DeleteEntity(UserContactDB);
                    _UnitOfWork.UserContactRepository.Save();

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

    }
}