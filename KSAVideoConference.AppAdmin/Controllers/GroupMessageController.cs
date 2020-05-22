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
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class GroupMessageController : Controller
    {
        private readonly ILogger<GroupMessageController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public GroupMessageController(ILogger<GroupMessageController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        // GET: GroupMessage
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index(int Fk_Group = 0, int Fk_User = 0)
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.GroupMessageRepository.GetAllAsyncIclude(Fk_Group, Fk_User, AppMainData.Email));
            }

            return View(await _UnitOfWork.GroupMessageRepository.GetAllAsyncIclude(Fk_Group, Fk_User));
        }

        // GET: GroupMessage/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            GroupMessage GroupMessage = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(id);

            if (GroupMessage == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMessage.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(GroupMessage);
        }

        // GET: GroupMessage/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            GroupMessage GroupMessage = new GroupMessage();

            if (id > 0)
            {
                GroupMessage = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(id);
                if (GroupMessage == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMessage.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(GroupMessage);
        }

        // POST: GroupMessage/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, GroupMessage GroupMessage)
        {
            if (id != GroupMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.GroupMessageRepository.CreateEntityAsync(GroupMessage);
                        await _UnitOfWork.GroupMessageRepository.SaveAsync();
                    }
                    else
                    {
                        GroupMessage Data = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        _Mapper.Map(GroupMessage, Data);

                        _UnitOfWork.GroupMessageRepository.UpdateEntity(Data);
                        await _UnitOfWork.GroupMessageRepository.SaveAsync();

                        GroupMessage = Data;
                    }

                    IFormFile files = HttpContext.Request.Form.Files["ImageFile"];
                    if (files != null)
                    {
                        await _UnitOfWork.GroupMessageRepository.UploudFile(GroupMessage, files);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.GroupMessageRepository.Any(a => a.Id == id))
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
            return View(GroupMessage);
        }

        // GET: GroupMessage/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            GroupMessage GroupMessage = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(id);
            if (GroupMessage == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMessage.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = true;

            //if (id == (int)GroupMessageEnum.Member )
            //{
            //    ViewBag.CanDelete = false;
            //}

            return View(GroupMessage);
        }

        // POST: GroupMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            GroupMessage GroupMessage = await _UnitOfWork.GroupMessageRepository.GetByIDAsyncIclude(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMessage.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            _UnitOfWork.GroupMessageRepository.DeleteEntity(GroupMessage);

            await _UnitOfWork.GroupMessageRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}