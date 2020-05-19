using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AuthModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.Repository.AuthRepository
{
    public class SystemUserPermissionRepository : AppBaseRepository<SystemUserPermission>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public SystemUserPermissionRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }



        public SystemUserPermission GetUserPermission(string Email, string ViewName)
        {
            return DBContext.SystemUserPermission.Where(a => a.SystemUser.Email == Email && a.SystemView.Name == ViewName).FirstOrDefault();
        }

        public bool CheckAuthorization(string ViewName, int Fk_AccessLevel)
        {
            if (Fk_AccessLevel == (int)AccessLevelEnum.FullAccess)
            {
                return IsFullAccess(ViewName);
            }
            else if (Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess)
            {
                return IsControlAccess(ViewName);
            }
            else if (Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
            {
                return IsViewAccess(ViewName);
            }

            return false;
        }

        public bool IsControlAccess(string ViewName)
        {
            return DBContext.SystemUserPermission.Where(a => a.SystemUser.Email == AppMainData.Email && a.SystemView.Name == ViewName)
                                                 .Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess ||
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess)
                                                 .Any();
        }

        public bool IsFullAccess(string ViewName)
        {
            return DBContext.SystemUserPermission.Where(a => a.SystemUser.Email == AppMainData.Email && a.SystemView.Name == ViewName &&
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess)
                                                 .Any();
        }

        public bool IsViewAccess(string ViewName)
        {
            return DBContext.SystemUserPermission.Where(a => a.SystemUser.Email == AppMainData.Email && a.SystemView.Name == ViewName &&
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                                                 .Any();
        }

        public bool IsOwner(string CreatedBy)
        {
            var SystemUser = DBContext.SystemUser.Where(a => a.Email == AppMainData.Email).FirstOrDefault();
            if (SystemUser != null)
            {
                if (SystemUser.Fk_ControlLevel == (int)ControlLevelEnum.All)
                {
                    return true;
                }
                else if (AppMainData.Email == CreatedBy)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<List<SystemUserPermission>> GetAllAsyncIclude()
        {
            return await DBContext.SystemUserPermission
                                  .Include(a => a.SystemUser)
                                  .Include(a => a.SystemView)
                                  .Include(a => a.AccessLevel)
                                  .ToListAsync();
        }

        public async Task<SystemUserPermission> GetByIDAsyncIclude(int id)
        {
            return await DBContext.SystemUserPermission
                                  .Where(a => a.Id == id)
                                  .Include(a => a.SystemUser)
                                  .Include(a => a.SystemView)
                                  .Include(a => a.AccessLevel)
                                  .FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteEntity(int id)
        {
            SystemUserPermission data = await GetByIDAsync(id);
            if (data.CreatedBy == AppMainData.SeedData)
            {
                return false;
            }
            return true;
        }

        public new void DeleteEntity(List<SystemUserPermission> entities)
        {
            foreach (SystemUserPermission entity in entities)
            {
                DeleteEntity(entity);
            }
        }

        public new void DeleteEntity(SystemUserPermission entity)
        {
            if (entity.CreatedBy != AppMainData.SeedData)
            {
                DBContext.Set<SystemUserPermission>().Remove(entity);
            }
        }
    }
}
