using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class MemberTypeController : Controller
    {
        private readonly ILogger<MemberTypeController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public MemberTypeController(ILogger<MemberTypeController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        // GET: MemberType
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.MemberTypeRepository.GetAllAsync(AppMainData.Email));
            }

            return View(await _UnitOfWork.MemberTypeRepository.GetAllAsync());
        }

        // GET: MemberType/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            MemberType MemberType = await _UnitOfWork.MemberTypeRepository.GetByIDAsync(id);

            if (MemberType == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(MemberType.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(MemberType);
        }

        // GET: MemberType/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            MemberType MemberType = new MemberType();

            if (id > 0)
            {
                MemberType = await _UnitOfWork.MemberTypeRepository.GetByIDAsync(id);
                if (MemberType == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(MemberType.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(MemberType);
        }

        // POST: MemberType/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, MemberType MemberType)
        {
            if (id != MemberType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.MemberTypeRepository.CreateEntityAsync(MemberType);
                        await _UnitOfWork.MemberTypeRepository.SaveAsync();
                    }
                    else
                    {
                        MemberType Data = await _UnitOfWork.MemberTypeRepository.GetByIDAsync(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        _Mapper.Map(MemberType, Data);

                        _UnitOfWork.MemberTypeRepository.UpdateEntity(Data);
                        await _UnitOfWork.MemberTypeRepository.SaveAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.MemberTypeRepository.Any(a => a.Id == id))
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
            return View(MemberType);
        }

        // GET: MemberType/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            MemberType MemberType = await _UnitOfWork.MemberTypeRepository.GetByIDAsync(id);
            if (MemberType == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(MemberType.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = true;

            if (id == (int)MemberTypeEnum.Member)
            {
                ViewBag.CanDelete = false;
            }

            return View(MemberType);
        }

        // POST: MemberType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            MemberType MemberType = await _UnitOfWork.MemberTypeRepository.GetByIDAsync(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(MemberType.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            _UnitOfWork.MemberTypeRepository.DeleteEntity(MemberType);

            await _UnitOfWork.MemberTypeRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}