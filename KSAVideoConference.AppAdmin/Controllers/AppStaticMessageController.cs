using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    public class AppStaticMessageController : Controller
    {
        private readonly ILogger<AppStaticMessageController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly ISession _Session;

        public AppStaticMessageController(ILogger<AppStaticMessageController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper, IHttpContextAccessor HttpContextAccessor)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            _Session = HttpContextAccessor.HttpContext.Session;
        }

        // GET: AppStaticMessage
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.AppStaticMessageRepository.GetAllAsync(AppMainData.Email));
            }
            return View(await _UnitOfWork.AppStaticMessageRepository.GetAllAsyncIclude());
        }

        // GET: AppStaticMessage/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            AppStaticMessage AppStaticMessage = await _UnitOfWork.AppStaticMessageRepository.GetByIDAsyncIclude(id);

            if (AppStaticMessage == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticMessage.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(AppStaticMessage);
        }

        // GET: AppStaticMessage/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AppStaticMessage AppStaticMessage = new AppStaticMessage();

            if (id > 0)
            {
                AppStaticMessage = await _UnitOfWork.AppStaticMessageRepository.GetByIDAsyncIclude(id);
                if (AppStaticMessage == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticMessage.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(AppStaticMessage);
        }

        // POST: AppStaticMessage/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, AppStaticMessage AppStaticMessage, AppStaticMessageLang AppStaticMessageLang)
        {
            if (id != AppStaticMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        AppStaticMessage.AppStaticMessageLangs = new List<AppStaticMessageLang>
                        {
                            AppStaticMessageLang
                        };
                        _UnitOfWork.AppStaticMessageRepository.CreateEntityAsync(AppStaticMessage);
                        await _UnitOfWork.AppStaticMessageRepository.SaveAsync();
                    }
                    else
                    {
                        AppStaticMessage Data = await _UnitOfWork.AppStaticMessageRepository.GetByIDAsyncIclude(id);
                       
                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }
                        _Mapper.Map(AppStaticMessage, Data);

                        AppStaticMessageLang OldAppStaticMessageLang = Data.AppStaticMessageLangs.FirstOrDefault();
                        if (OldAppStaticMessageLang != null)
                        {
                            Data.AppStaticMessageLangs.Remove(OldAppStaticMessageLang);
                            _Mapper.Map(AppStaticMessageLang, OldAppStaticMessageLang);
                            Data.AppStaticMessageLangs.Add(OldAppStaticMessageLang);
                        }
                        else
                        {
                            Data.AppStaticMessageLangs = new List<AppStaticMessageLang>
                            {
                                AppStaticMessageLang
                            };
                        }

                        _UnitOfWork.AppStaticMessageRepository.UpdateEntity(Data);
                        await _UnitOfWork.AppStaticMessageRepository.SaveAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.AppStaticMessageRepository.Any(a => a.Id == id))
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
            return View(AppStaticMessage);
        }

        // GET: AppStaticMessage/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            AppStaticMessage AppStaticMessage = await _UnitOfWork.AppStaticMessageRepository.GetByIDAsync(id);
            if (AppStaticMessage == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticMessage.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = false;

            if (AppStaticMessage != null)
            {
                ViewBag.CanDelete = true;
            }

            return View(AppStaticMessage);
        }

        // POST: AppStaticMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AppStaticMessage AppStaticMessage = await _UnitOfWork.AppStaticMessageRepository.GetByIDAsync(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(AppStaticMessage.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }
            _UnitOfWork.AppStaticMessageRepository.DeleteEntity(AppStaticMessage);

            await _UnitOfWork.AppStaticMessageRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

