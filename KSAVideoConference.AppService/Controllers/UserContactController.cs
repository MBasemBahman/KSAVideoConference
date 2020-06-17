using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
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
        [Route(nameof(AddContact))]
        public async Task<int> AddContact([FromQuery] Guid Token, [FromBody] List<string> Phones)
        {
            int returnData = 0;
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
                    var Length = 10;
                    if (Phones != null && Phones.Any())
                    {
                        for (int i = 0; i < Phones.Count; i++)
                        {
                            Phones[i] = Phones[i].Substring(Phones[i].Length - Length, Length);
                        }

                        var Users = await _UnitOfWork.UserRepository.GetAllAsync(a => Phones.Contains(a.Phone.Substring(a.Phone.Length - Length, Length)));
                        
                        if (Users.Any())
                        {
                            UserDB.MyUserContacts = new List<UserContact>();

                            Users.ForEach(Contact => UserDB.MyUserContacts.Add(new UserContact { Fk_Contact = Contact.Id }));

                            _UnitOfWork.UserRepository.UpdateEntity(UserDB);
                            _UnitOfWork.UserRepository.Save();

                            returnData = Users.Count;
                        }
                    }

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
        /// Delete : Delete Contact
        /// </summary>
        [HttpDelete]
        [Route(nameof(DeleteContact))]
        public async Task<bool> DeleteContact([FromQuery] Guid Token, [FromBody] IUserContactModel UserContact)
        {
            bool returnData = new bool();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                UserContact UserContactDB = await _UnitOfWork.UserContactRepository.GetByIDAsyncIclude(UserContact.Id);

                if (UserContactDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);
                }
                else if (UserDB == null)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnAuth);
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.UnActive, UserDB.Fk_Language);
                }
                else if (UserContactDB.Fk_User != UserDB.Id)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.NotOwner, UserDB.Fk_Language);
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

            Status.ErrorMessage = _UnitOfWork.AppStaticMessageRepository.Encode(Status.ErrorMessage);
            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status));

            return returnData;
        }

    }
}