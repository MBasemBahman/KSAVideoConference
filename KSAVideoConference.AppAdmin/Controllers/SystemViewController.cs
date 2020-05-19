using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AuthModel;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class SystemViewController : Controller
    {
        private readonly ILogger<SystemViewController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public SystemViewController(ILogger<SystemViewController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        // GET: SystemView
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.SystemViewRepository.GetAllAsync(AppMainData.Email));
            }

            return View(await _UnitOfWork.SystemViewRepository.GetAllAsync());
        }

        // GET: SystemView/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            SystemView SystemView = await _UnitOfWork.SystemViewRepository.GetByIDAsync(id);

            if (SystemView == null)
            {
                return NotFound();
            }

            return View(SystemView);
        }

        // GET: SystemView/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            SystemView SystemView = new SystemView();

            if (id > 0)
            {
                SystemView = await _UnitOfWork.SystemViewRepository.GetByIDAsync(id);
                if (SystemView == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemView.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(SystemView);
        }

        // POST: SystemView/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, SystemView SystemView)
        {
            if (id != SystemView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.SystemViewRepository.CreateEntityAsync(SystemView);
                        await _UnitOfWork.SystemViewRepository.SaveAsync();
                    }
                    else
                    {
                        SystemView Data = await _UnitOfWork.SystemViewRepository.GetByIDAsync(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        _Mapper.Map(SystemView, Data);

                        _UnitOfWork.SystemViewRepository.UpdateEntity(Data);
                        await _UnitOfWork.SystemViewRepository.SaveAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.SystemViewRepository.Any(a => a.Id == id))
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
            return View(SystemView);
        }

        // GET: SystemView/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            SystemView SystemView = await _UnitOfWork.SystemViewRepository.GetByIDAsync(id);
            if (SystemView == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemView.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = true;

            if (id == (int)SystemViewEnum.SystemView || id == (int)SystemViewEnum.SystemUser
                || id == (int)SystemViewEnum.Home)
            {
                ViewBag.CanDelete = false;
            }

            return View(SystemView);
        }

        // POST: SystemView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            SystemView SystemView = await _UnitOfWork.SystemViewRepository.GetByIDAsync(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(SystemView.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            _UnitOfWork.SystemViewRepository.DeleteEntity(SystemView);

            await _UnitOfWork.SystemViewRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}