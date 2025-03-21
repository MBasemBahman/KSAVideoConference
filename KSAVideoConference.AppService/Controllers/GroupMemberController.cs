﻿using AutoMapper;
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
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

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
        [Route(nameof(JoinGroup))]
        public async Task<GroupModel> JoinGroup([FromQuery] Guid Token, [FromBody] IGroupMemberModel GroupMember)
        {
            GroupModel returnData = new GroupModel();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                Group GroupDB = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(GroupMember.Fk_Group);

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
                else if (!ModelState.IsValid)
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.InCompleteData, UserDB.Fk_Language);
                }
                else
                {
                    if (GroupDB.Fk_Creator != GroupMember.Fk_User)
                    {
                        GroupMember GroupMemberDB = GroupDB.GroupMembers.FirstOrDefault(a => a.Fk_User == GroupMember.Fk_User);

                        if (GroupMemberDB == null)
                        {
                            GroupMemberDB = new GroupMember();
                            _Mapper.Map(GroupMember, GroupMemberDB);

                            if (GroupDB.GroupMembers == null)
                            {
                                GroupDB.GroupMembers = new List<GroupMember>();
                            }
                            GroupDB.GroupMembers.Add(GroupMemberDB);

                            IUserContactModel UserContact = new IUserContactModel
                            {
                                Fk_Contact = GroupMemberDB.Fk_User,
                            };

                            UserDB = _UnitOfWork.UserContactRepository.AddContact(UserContact, UserDB);

                            _UnitOfWork.UserRepository.UpdateEntity(UserDB);

                            _UnitOfWork.GroupRepository.UpdateEntity(GroupDB);
                            _UnitOfWork.GroupRepository.Save();

                            await _hubContext.Groups.AddToGroupAsync(UserDB.Id.ToString(), GroupDB.Id.ToString());
                            await _hubContext.Clients.Group(GroupDB.Id.ToString()).Send($"{UserDB.FullName} لقد انضم إلى المجموعة {GroupDB.Name}.");
                        }
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
        /// Post : Edit Member Type
        /// </summary>
        [HttpPost]
        [Route(nameof(EditMemberType))]
        public async Task<bool> EditMemberType([FromQuery] Guid Token, [FromBody] IGroupMemberModel GroupMember)
        {
            bool returnData = new bool();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                GroupMember GroupMemberDB = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(GroupMember.Id);

                if (GroupMemberDB == null)
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
                else if (!await _UnitOfWork.GroupMemberRepository.IsAdmin(GroupMemberDB.Fk_Group, UserDB.Id))
                {
                    Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.NotOwner, UserDB.Fk_Language);
                }
                else
                {
                    _Mapper.Map(GroupMember, GroupMemberDB);
                    _UnitOfWork.GroupMemberRepository.UpdateEntity(GroupMemberDB);
                    await _UnitOfWork.GroupMemberRepository.SaveAsync();

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

        /// <summary>
        /// Patch : Exit Group
        /// </summary>
        [HttpPatch]
        [Route(nameof(ExitGroup))]
        public async Task<bool> ExitGroup([FromQuery] Guid Token, [FromBody] IGroupMemberModel GroupMember)
        {
            bool returnData = new bool();
            Status Status = new Status();

            try
            {
                Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.Common);

                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                GroupMember GroupMemberDB = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(GroupMember.Id);

                if (GroupMemberDB == null)
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
                else
                {
                    bool valid = false;

                    if (await _UnitOfWork.GroupMemberRepository.IsAdmin(GroupMemberDB.Fk_Group, UserDB.Id))
                    {
                        valid = true;
                    }
                    else if (GroupMemberDB.Fk_User == UserDB.Id)
                    {
                        valid = true;
                    }

                    if (valid)
                    {
                        _UnitOfWork.GroupMemberRepository.DeleteEntity(GroupMemberDB);
                        await _UnitOfWork.GroupMemberRepository.SaveAsync();

                        await _hubContext.Groups.RemoveFromGroupAsync(UserDB.Id.ToString(), GroupMemberDB.Fk_Group.ToString());
                        await _hubContext.Clients.Group(GroupMemberDB.Fk_Group.ToString()).Send($"{UserDB.FullName} غادر المجموعة {GroupMemberDB.Group.Name}.");

                        returnData = true;
                        Status = new Status(true);
                    }
                    else
                    {
                        Status.ErrorMessage = await _UnitOfWork.AppStaticMessageRepository.GetStaticMessage((int)AppStaticMessageEnum.NotOwner, UserDB.Fk_Language);
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
    }
}