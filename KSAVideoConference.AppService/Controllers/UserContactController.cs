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
        public async Task<UserContactModel> AddContact([FromQuery]Guid Token, [FromBody]IUserContactModel UserContact)
        {
            UserContactModel returnData = new UserContactModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                User ContactDB = await _UnitOfWork.UserRepository.GetByIDAsyncIclude(UserContact.Fk_Contact);

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
                    UserContact UserContactDB = new UserContact();
                    _Mapper.Map(UserContact, UserContactDB);

                    UserDB.MyUserContacts.Add(UserContactDB);

                    _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                    _UnitOfWork.UserRepository.Save();

                    Status = new Status(true);

                    _Mapper.Map(UserContactDB, returnData);
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
        /// Delete : Delete Contact
        /// </summary>
        [HttpDelete]
        [Route("DeleteContact")]
        public async Task<UserContactModel> DeleteContact([FromQuery]Guid Token, [FromBody]IUserContactModel UserContact)
        {
            UserContactModel returnData = new UserContactModel();
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                UserContact UserContactDB = await _UnitOfWork.UserContactRepository.GetByIDAsyncIclude(UserContact.Id);

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
                    _UnitOfWork.UserContactRepository.DeleteEntity(UserContactDB);
                    _UnitOfWork.UserContactRepository.Save();

                    Status = new Status(true);

                    _Mapper.Map(UserContactDB, returnData);
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