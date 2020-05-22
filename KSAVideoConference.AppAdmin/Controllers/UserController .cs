﻿using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.AppAdmin.Services;
using KSAVideoConference.AppAdmin.ViewModel;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity;
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
    public class UserController : Controller
    {
       
        private readonly ILogger<UserController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly AppSetting _AppSetting;


        public UserController(ILogger<UserController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper, AppSetting AppSetting)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            _AppSetting = AppSetting;

        }
        // GET: User
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index()
        {
            return View(await _UnitOfWork.UserRepository.GetAllAsyncIclude());
        }

        // GET: User/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            User User = await _UnitOfWork.UserRepository.GetByIDAsyncIclude(id);

            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        // GET: User/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            User User = new User();

            if (id > 0)
            {
                User = await _UnitOfWork.UserRepository.GetByIDAsyncIclude(id);
                if (User == null)
                {
                    return NotFound();
                }
            }

            return View(GetViewModel(User));
        }

        // POST: User/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, User User, List<int> SelectedUserContacts)
        {
            if (id != User.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {

                        if (SelectedUserContacts != null && SelectedUserContacts.Any())
                        {
                            User.MyUserContacts = new List<UserContact>();
                            User = AddUserMembers(User, SelectedUserContacts);
                        }

                        _UnitOfWork.UserRepository.CreateEntityAsync(User);
                        await _UnitOfWork.UserRepository.SaveAsync();

                    }
                    else
                    {
                        User Data = await _UnitOfWork.UserRepository.GetByIDAsyncIclude(id);

                        _Mapper.Map(User, Data);


                        List<int> OldData = Data.MyUserContacts.Select(a => a.Fk_Contact).ToList();
                        IEnumerable<int> RmvIds = OldData.Except(SelectedUserContacts);
                        IEnumerable<int> AddIds = SelectedUserContacts.Except(OldData);

                        if (RmvIds.Any() && Data.MyUserContacts.Any())
                        {
                            List<UserContact> removeOldData = Data.MyUserContacts.Where(a => RmvIds.Contains(a.Fk_Contact)).ToList();
                            if (removeOldData.Any())
                            {
                                foreach (UserContact data in removeOldData)
                                {
                                    Data.MyUserContacts.Remove(data);
                                }
                            }
                        }

                        if (AddIds != null && AddIds.Any())
                        {
                            Data = AddUserMembers(Data, AddIds.ToList());
                        }


                        _UnitOfWork.UserRepository.UpdateEntity(Data);
                        await _UnitOfWork.UserRepository.SaveAsync();

                        User = Data;

                    }

                    IFormFile filesEn = HttpContext.Request.Form.Files["ImageFile"];
                    if (filesEn != null)
                    {
                        ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                        string ImgURl = await ImgManager.UploudImageAsync(AppMainData.DomainName, User.Id.ToString(), filesEn, "test1");

                        if (!string.IsNullOrEmpty(ImgURl))
                        {
                            if (!string.IsNullOrEmpty(User.ImageURL))
                            {
                                ImgManager.DeleteImage(User.ImageURL, AppMainData.DomainName);
                            }
                            User.ImageURL = ImgURl;
                            _UnitOfWork.UserRepository.UpdateEntity(User);
                            await _UnitOfWork.UserRepository.SaveAsync();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.UserRepository.Any(a => a.Id == id))
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
            return View(GetViewModel(User));
        }

        public UserViewModel GetViewModel(User User)
        {
            UserViewModel Data = new UserViewModel()
            {
                User = User
            };

            if (User != null && User.MyUserContacts != null)
            {
                Data.SelectedUserContacts = User.MyUserContacts.Select(a => a.Fk_Contact).ToList();
            }

            return Data;
        }
        public User AddUserMembers(User User, List<int> SelectedAcountDevice)
        {
            foreach (int Fk_Contact in SelectedAcountDevice)
            {
                User.MyUserContacts.Add(new UserContact
                {
                    Fk_Contact = Fk_Contact,
                });
            }
            return User;
        }

        // GET: User/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            User User = await _UnitOfWork.UserRepository.GetByIDAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = false;

            if (User != null)
            {
                ViewBag.CanDelete = true;
            }

            return View(User);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            User User = await _UnitOfWork.UserRepository.GetByIDAsyncIclude(id);

            ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);
            if (!string.IsNullOrEmpty(User.ImageURL))
            {
                ImgManager.DeleteImage(User.ImageURL, AppMainData.DomainName);
            }

            _UnitOfWork.UserContactRepository.DeleteEntity(User.MyUserContacts.ToList());

            _UnitOfWork.UserRepository.DeleteEntity(User);

            await _UnitOfWork.UserRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
