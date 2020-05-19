using AutoMapper;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AuthModel;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.AppAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly ISession _Session;

        public LoginController(ILogger<LoginController> logger, DataContext DBContext,
                               AppUnitOfWork UnitOfWork, IMapper Mapper,
                               IHttpContextAccessor HttpContextAccessor)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            _Session = HttpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            _Session.Clear();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SystemUser systemUser)
        {
            try
            {
                if (_UnitOfWork.SystemUserRepository.UserExists(systemUser.Email, systemUser.Password))
                {
                    systemUser = _UnitOfWork.SystemUserRepository.GetByEmail(systemUser.Email);

                    _Session.SetString("Email", systemUser.Email);
                    _Session.SetString("FullName", systemUser.FullName);
                    _Session.SetString("JopTitle", systemUser.JopTitle);

                    AppMainData.Email = systemUser.Email;
                    SetUserViews();

                    return RedirectToAction(nameof(Index), "Home");
                }

                ViewData["Error"] = "Email or Password Are Wrong, Or Acount Is Deactive!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_UnitOfWork.SystemUserRepository.UserExists(systemUser.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(systemUser);
        }

        public void SetUserViews()
        {
            List<SystemView> SystemViews = _UnitOfWork.SystemViewRepository.GetSystemViews();
            if (SystemViews.Any())
            {
                List<string> Views = SystemViews.Select(a => a.Name).ToList();
                foreach (string View in Views)
                {
                    _Session.SetString(View, View);
                }
            }
        }

        public IActionResult Edit()
        {
            string Email = AppMainData.Email;
            if (Email == null)
            {
                return NotFound();
            }
            return View(_UnitOfWork.SystemUserRepository.GetByEmail(Email));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SystemUser systemUser)
        {
            try
            {
                string Email = AppMainData.Email;
                if (Email == null)
                {
                    return NotFound();
                }

                systemUser.IsActive = true;

                SystemUser Data = _UnitOfWork.SystemUserRepository.GetByEmail(Email);

                _Mapper.Map(systemUser, Data);

                _UnitOfWork.SystemUserRepository.UpdateEntity(Data);
                await _UnitOfWork.SystemUserRepository.SaveAsync();

                _Session.SetString("Email", systemUser.Email);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_UnitOfWork.SystemUserRepository.UserExists(systemUser.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        public IActionResult Logout()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}