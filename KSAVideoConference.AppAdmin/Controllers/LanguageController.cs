using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class LanguageController : Controller
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public LanguageController(ILogger<LanguageController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        // GET: Language
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.LanguageRepository.GetAllAsync(AppMainData.Email));
            }

            return View(await _UnitOfWork.LanguageRepository.GetAllAsync());
        }

        // GET: Language/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            Language Language = await _UnitOfWork.LanguageRepository.GetByIDAsync(id);

            if (Language == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Language.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(Language);
        }

        // GET: Language/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            Language Language = new Language();

            if (id > 0)
            {
                Language = await _UnitOfWork.LanguageRepository.GetByIDAsync(id);
                if (Language == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Language.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(Language);
        }

        // POST: Language/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, Language Language)
        {
            if (id != Language.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.LanguageRepository.CreateEntityAsync(Language);
                        await _UnitOfWork.LanguageRepository.SaveAsync();
                    }
                    else
                    {
                        Language Data = await _UnitOfWork.LanguageRepository.GetByIDAsync(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        _Mapper.Map(Language, Data);

                        _UnitOfWork.LanguageRepository.UpdateEntity(Data);
                        await _UnitOfWork.LanguageRepository.SaveAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.LanguageRepository.Any(a => a.Id == id))
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
            return View(Language);
        }

        // GET: Language/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            Language Language = await _UnitOfWork.LanguageRepository.GetByIDAsync(id);
            if (Language == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Language.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = true;

            if (id == (int)LanguageEnum.Arabic || id == (int)LanguageEnum.English)
            {
                ViewBag.CanDelete = false;
            }

            return View(Language);
        }

        // POST: Language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Language Language = await _UnitOfWork.LanguageRepository.GetByIDAsync(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Language.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            _UnitOfWork.LanguageRepository.DeleteEntity(Language);

            await _UnitOfWork.LanguageRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}