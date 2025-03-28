﻿using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.AppAdmin.ViewModel;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    public class GroupController : Controller
    {

        private readonly ILogger<GroupController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public GroupController(ILogger<GroupController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: Group
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index(int id = 0, int Fk_User = 0)
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.GroupRepository.GetAllAsyncIclude(id, Fk_User, AppMainData.Email));
            }
            return View(await _UnitOfWork.GroupRepository.GetAllAsyncIclude(id, Fk_User));
        }

        // GET: Group/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            Group Group = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(id);

            if (Group == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Group.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(Group);
        }

        // GET: Group/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            Group Group = new Group();

            if (id > 0)
            {
                Group = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(id);
                if (Group == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Group.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(GetViewModel(Group));
        }

        // POST: Group/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, Group Group, List<int> SelectedGroupMembers)
        {
            if (id != Group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {

                        if (SelectedGroupMembers != null && SelectedGroupMembers.Any())
                        {
                            Group.GroupMembers = new List<GroupMember>();
                            Group = AddGroupMembers(Group, SelectedGroupMembers);
                        }

                        Group.SessionId = await OpenTokManager.CreateSessionId();

                        _UnitOfWork.GroupRepository.CreateEntityAsync(Group);
                        await _UnitOfWork.GroupRepository.SaveAsync();

                    }
                    else
                    {
                        Group Data = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        _Mapper.Map(Group, Data);


                        List<int> OldData = Data.GroupMembers.Select(a => a.Fk_User).ToList();
                        IEnumerable<int> RmvIds = OldData.Except(SelectedGroupMembers);
                        IEnumerable<int> AddIds = SelectedGroupMembers.Except(OldData);

                        if (RmvIds.Any() && Data.GroupMembers.Any())
                        {
                            List<GroupMember> removeOldData = Data.GroupMembers.Where(a => RmvIds.Contains(a.Fk_User)).ToList();
                            if (removeOldData.Any())
                            {
                                foreach (GroupMember data in removeOldData)
                                {
                                    Data.GroupMembers.Remove(data);
                                }
                            }
                        }

                        if (AddIds != null && AddIds.Any())
                        {
                            Data = AddGroupMembers(Data, AddIds.ToList());
                        }


                        _UnitOfWork.GroupRepository.UpdateEntity(Data);
                        await _UnitOfWork.GroupRepository.SaveAsync();

                        Group = Data;

                    }

                    IFormFile filesEn = HttpContext.Request.Form.Files["ImageFile"];
                    if (filesEn != null)
                    {
                        await _UnitOfWork.GroupRepository.UploudFile(Group, filesEn);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.GroupRepository.Any(a => a.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(GetViewModel(Group));
        }

        public GroupViewModel GetViewModel(Group Group)
        {
            GroupViewModel Data = new GroupViewModel()
            {
                Group = Group
            };

            if (Group != null && Group.GroupMembers != null)
            {
                Data.SelectedGroupMembers = Group.GroupMembers.Select(a => a.Fk_User).ToList();
            }

            return Data;
        }
        public Group AddGroupMembers(Group Group, List<int> SelectedAcountDevice)
        {
            SelectedAcountDevice = SelectedAcountDevice.Where(a => a != Group.Fk_Creator).ToList();
            foreach (int Fk_User in SelectedAcountDevice)
            {
                Group.GroupMembers.Add(new GroupMember
                {
                    Fk_User = Fk_User,
                });
            }
            return Group;
        }

        // GET: Group/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            Group Group = await _UnitOfWork.GroupRepository.GetByIDAsync(id);
            if (Group == null)
            {
                return NotFound();
            }
            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Group.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = false;

            if (Group != null)
            {
                ViewBag.CanDelete = true;
            }

            return View(Group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Group Group = await _UnitOfWork.GroupRepository.GetByIDAsyncIclude(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Group.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);
            if (!string.IsNullOrEmpty(Group.LogoURL))
            {
                ImgManager.DeleteImage(Group.LogoURL, AppMainData.DomainName);
            }

            _UnitOfWork.GroupMemberRepository.DeleteEntity(Group.GroupMembers.ToList());

            _UnitOfWork.GroupRepository.DeleteEntity(Group);

            await _UnitOfWork.GroupRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
