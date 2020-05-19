using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.AppAdmin.ViewModel;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AuthModel;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class SystemUserController : Controller
    {
        private readonly ILogger<SystemUserController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public SystemUserController(ILogger<SystemUserController> logger, DataContext DBContext,
                                    AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }


        // GET: SystemUser
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.SystemUserRepository.GetAllAsync(AppMainData.Email));
            }
            return View(await _UnitOfWork.SystemUserRepository.GetAllAsync());
        }

        // GET: SystemUser/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            SystemUser SystemUser = await _UnitOfWork.SystemUserRepository.GetByIDAsync(id);

            if (SystemUser == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemUser.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(SystemUser);
        }

        // GET: SystemUser/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            SystemUser SystemUser = new SystemUser();

            if (id > 0)
            {
                SystemUser = await _UnitOfWork.SystemUserRepository.GetByIDAsyncIclude(id);
                if (SystemUser == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemUser.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(GetViewModel(SystemUser));
        }

        // POST: SystemUser/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, SystemUser SystemUser, List<int> SelectedFullAccess,
                                                      List<int> SelectedControlAccess, List<int> SelectedViewAccess)
        {
            if (id != SystemUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.SystemUserRepository.CreateEntity(SystemUser);
                        _UnitOfWork.SystemUserRepository.Save();

                    }
                    else
                    {
                        SystemUser Data = await _UnitOfWork.SystemUserRepository.GetByIDAsync(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        _Mapper.Map(SystemUser, Data);

                        _UnitOfWork.SystemUserRepository.UpdateEntity(Data);

                        await _UnitOfWork.SystemUserRepository.SaveAsync();
                    }

                    _UnitOfWork.SystemUserPermissionRepository.DeleteEntity(await _UnitOfWork.SystemUserPermissionRepository.GetAllAsync(a => a.Fk_SystemUser == id));

                    _UnitOfWork.SystemUserPermissionRepository.CreateEntityAsync(new SystemUserPermission
                    {
                        Fk_SystemView = (int)SystemViewEnum.Home,
                        Fk_SystemUser = SystemUser.Id,
                        Fk_AccessLevel = (int)AccessLevelEnum.ViewAccess
                    });

                    if (SelectedFullAccess != null && SelectedFullAccess.Any())
                    {
                        foreach (int item in SelectedFullAccess)
                        {
                            _UnitOfWork.SystemUserPermissionRepository.CreateEntityAsync(new SystemUserPermission
                            {
                                Fk_SystemView = item,
                                Fk_SystemUser = SystemUser.Id,
                                Fk_AccessLevel = (int)AccessLevelEnum.FullAccess
                            });
                        }
                    }

                    if (SelectedControlAccess != null && SelectedControlAccess.Any())
                    {
                        if (SelectedFullAccess != null && SelectedFullAccess.Any())
                        {
                            SelectedControlAccess = SelectedControlAccess.Where(a => !SelectedFullAccess.Contains(a)).ToList();
                        }

                        foreach (int item in SelectedControlAccess)
                        {
                            _UnitOfWork.SystemUserPermissionRepository.CreateEntityAsync(new SystemUserPermission
                            {
                                Fk_SystemView = item,
                                Fk_SystemUser = SystemUser.Id,
                                Fk_AccessLevel = (int)AccessLevelEnum.ControlAccess
                            });
                        }
                    }

                    if (SelectedViewAccess != null && SelectedViewAccess.Any())
                    {
                        if (SelectedFullAccess != null && SelectedFullAccess.Any())
                        {
                            SelectedViewAccess = SelectedViewAccess.Where(a => !SelectedFullAccess.Contains(a)).ToList();
                        }

                        if (SelectedControlAccess != null && SelectedControlAccess.Any())
                        {
                            SelectedViewAccess = SelectedViewAccess.Where(a => !SelectedControlAccess.Contains(a)).ToList();
                        }

                        foreach (int item in SelectedViewAccess)
                        {
                            _UnitOfWork.SystemUserPermissionRepository.CreateEntityAsync(new SystemUserPermission
                            {
                                Fk_SystemView = item,
                                Fk_SystemUser = SystemUser.Id,
                                Fk_AccessLevel = (int)AccessLevelEnum.ViewAccess
                            });
                        }
                    }

                    _UnitOfWork.SystemUserPermissionRepository.Save();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.SystemUserRepository.Any(a => a.Id == id))
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

            return View(GetViewModel(SystemUser));
        }

        // GET: SystemUser/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            SystemUser SystemUser = await _UnitOfWork.SystemUserRepository.GetByIDAsync(id);
            if (SystemUser == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemUser.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = true;

            if (id == 1)
            {
                ViewBag.CanDelete = false;
            }

            return View(SystemUser);
        }

        // POST: SystemUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            SystemUser SystemUser = await _UnitOfWork.SystemUserRepository.GetByIDAsync(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemUser.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            _UnitOfWork.SystemUserRepository.DeleteEntity(SystemUser);

            await _UnitOfWork.SystemUserRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public SystemUserViewModel GetViewModel(SystemUser SystemUser)
        {
            SystemUserViewModel data = new SystemUserViewModel
            {
                SystemUser = SystemUser,
                SelectedFullAccess = SystemUser.SystemUserPermissions.Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess).Select(a => a.Fk_SystemView).ToList(),
                SelectedControlAccess = SystemUser.SystemUserPermissions.Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess).Select(a => a.Fk_SystemView).ToList(),
                SelectedViewAccess = SystemUser.SystemUserPermissions.Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess).Select(a => a.Fk_SystemView).ToList(),
            };

            return data;
        }
    }
}