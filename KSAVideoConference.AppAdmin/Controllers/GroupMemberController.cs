
using AutoMapper;
using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class GroupMemberController : Controller
    {
        private readonly ILogger<GroupMemberController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public GroupMemberController(ILogger<GroupMemberController> logger, DataContext DBContext, AppUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _logger = logger;
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        // GET: GroupMember
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Index(int Fk_Group = 0, int Fk_User = 0)
        {
            if (_UnitOfWork.ControlLevelRepository.GetControlLevel() == (int)ControlLevelEnum.Owner)
            {
                return View(await _UnitOfWork.GroupMemberRepository.GetAllAsyncIclude(Fk_Group, Fk_User, AppMainData.Email));
            }

            return View(await _UnitOfWork.GroupMemberRepository.GetAllAsyncIclude(Fk_Group, Fk_User));
        }

        // GET: GroupMember/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public async Task<IActionResult> Details(int id)
        {
            GroupMember GroupMember = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(id);

            if (GroupMember == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMember.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            return View(GroupMember);
        }

        // GET: GroupMember/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            GroupMember GroupMember = new GroupMember();

            if (id > 0)
            {
                GroupMember = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(id);
                if (GroupMember == null)
                {
                    return NotFound();
                }

                if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMember.CreatedBy))
                {
                    return View(AppMainData.UnAuthorized);
                }
            }

            return View(GroupMember);
        }

        // POST: GroupMember/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, GroupMember GroupMember)
        {
            if (id != GroupMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        Group Group = await _UnitOfWork.GroupRepository.GetByIDAsync(GroupMember.Fk_Group);
                        if (Group.Fk_Creator != GroupMember.Fk_User)
                        {
                            if (!_DBContext.GroupMember.Any(a => a.Fk_User == GroupMember.Fk_User && a.Fk_Group == GroupMember.Fk_Group))
                            {
                                _UnitOfWork.GroupMemberRepository.CreateEntityAsync(GroupMember);
                                await _UnitOfWork.GroupMemberRepository.SaveAsync();
                            }
                        }
                    }
                    else
                    {
                        GroupMember Data = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(id);

                        if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(Data.CreatedBy))
                        {
                            return View(AppMainData.UnAuthorized);
                        }

                        if (Data.Group.Fk_Creator == GroupMember.Fk_User ||
                            !_DBContext.GroupMember.Any(a => a.Fk_User == GroupMember.Fk_User && a.Fk_Group == GroupMember.Fk_Group && a.Id == Data.Id))
                        {
                            GroupMember.Fk_User = Data.Fk_User;
                        }
                        _Mapper.Map(GroupMember, Data);

                        _UnitOfWork.GroupMemberRepository.UpdateEntity(Data);
                        await _UnitOfWork.GroupMemberRepository.SaveAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.GroupMemberRepository.Any(a => a.Id == id))
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
            return View(GroupMember);
        }

        // GET: GroupMember/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> Delete(int id)
        {
            GroupMember GroupMember = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(id);
            if (GroupMember == null)
            {
                return NotFound();
            }

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMember.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            ViewBag.CanDelete = true;

            return View(GroupMember);
        }

        // POST: GroupMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            GroupMember GroupMember = await _UnitOfWork.GroupMemberRepository.GetByIDAsyncIclude(id);

            if (!_UnitOfWork.SystemUserPermissionRepository.IsOwner(GroupMember.CreatedBy))
            {
                return View(AppMainData.UnAuthorized);
            }

            _UnitOfWork.GroupMemberRepository.DeleteEntity(GroupMember);

            await _UnitOfWork.GroupMemberRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}