using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
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
    public class AppStaticWordController : Controller
    {
        private readonly ILogger<AppStaticWordController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly ISession _Session;

        public AppStaticWordController(ILogger<AppStaticWordController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper, IHttpContextAccessor HttpContextAccessor)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            _Session = HttpContextAccessor.HttpContext.Session;
        }

        // GET: AppStaticWord
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.AppStaticWordRepository.GetAllAsync(AppMainData.Email));
            }
            return View(await _UnitOfWork.AppStaticWordRepository.GetAllAsyncIclude());
        }

        // GET: AppStaticWord/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            AppStaticWord AppStaticWord = await _UnitOfWork.AppStaticWordRepository.GetByIDAsyncIclude(id);

            if (AppStaticWord == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticWord.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(AppStaticWord);
        }

        // GET: AppStaticWord/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AppStaticWord AppStaticWord = new AppStaticWord();

            if (id > 0)
            {
                AppStaticWord = await _UnitOfWork.AppStaticWordRepository.GetByIDAsyncIclude(id);
                if (AppStaticWord == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticWord.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(AppStaticWord);
        }

        // POST: AppStaticWord/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, AppStaticWord AppStaticWord, AppStaticWordLang AppStaticWordLang)
        {
            if (id != AppStaticWord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        AppStaticWord.AppStaticWordLangs = new List<AppStaticWordLang>
                        {
                            AppStaticWordLang
                        };
                        _UnitOfWork.AppStaticWordRepository.CreateEntityAsync(AppStaticWord);
                        await _UnitOfWork.AppStaticWordRepository.SaveAsync();
                    }
                    else
                    {
                        AppStaticWord Data = await _UnitOfWork.AppStaticWordRepository.GetByIDAsyncIclude(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }
                        _Mapper.Map(AppStaticWord, Data);

                        AppStaticWordLang OldAppStaticWordLang = Data.AppStaticWordLangs.FirstOrDefault();
                        if (OldAppStaticWordLang != null)
                        {
                            Data.AppStaticWordLangs.Remove(OldAppStaticWordLang);
                            _Mapper.Map(AppStaticWordLang, OldAppStaticWordLang);
                            Data.AppStaticWordLangs.Add(OldAppStaticWordLang);
                        }
                        else
                        {
                            Data.AppStaticWordLangs = new List<AppStaticWordLang>
                            {
                                AppStaticWordLang
                            };
                        }

                        _UnitOfWork.AppStaticWordRepository.UpdateEntity(Data);
                        await _UnitOfWork.AppStaticWordRepository.SaveAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.AppStaticWordRepository.Any(a => a.Id == id))
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
            return View(AppStaticWord);
        }

        // GET: AppStaticWord/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            AppStaticWord AppStaticWord = await _UnitOfWork.AppStaticWordRepository.GetByIDAsync(id);
            if (AppStaticWord == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticWord.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = false;

            if (await _UnitOfWork.AppStaticWordRepository.DeleteEntity(id))
            {
                ViewBag.CanDelete = true;
            }

            return View(AppStaticWord);
        }

        // POST: AppStaticWord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AppStaticWord AppStaticWord = await _UnitOfWork.AppStaticWordRepository.GetByIDAsync(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticWord.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }
            _UnitOfWork.AppStaticWordRepository.DeleteEntity(AppStaticWord);

            await _UnitOfWork.AppStaticWordRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

