using KSAVideoConference.DAL;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.Entity.AuthModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;
using AutoMapper;

namespace KSAVideoConference.Repository.AuthRepository
{
    public class SystemUserRepository : AppBaseRepository<SystemUser>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public SystemUserRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public bool UserExists(string Email, string Password = null)
        {
            return DBContext.SystemUser
                   .Where(a => a.Email == Email)
                   .Where(a => Password == null ? true : a.Password == Password)
                   .Where(a => a.IsActive == true)
                   .Any();
        }

        public SystemUser GetByEmail(string Email)
        {
            return DBContext.SystemUser.FirstOrDefault(a => a.Email == Email);
        }

        public bool CheckAuthorization(string Email, string ViewName, int Fk_AccessLevel)
        {
            SystemUserPermission SystemUser = DBContext.SystemUserPermission.FirstOrDefault(a => a.SystemUser.Email == Email && a.SystemView.Name == ViewName);

            if (SystemUser != null)
            {
                if (SystemUser.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess)
                {
                    return true;
                }
                else if (SystemUser.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess)
                {
                    if (Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess
                        || Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                    {
                        return true;
                    }
                }
                else if (SystemUser.Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                {
                    if (Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<List<SystemUser>> GetAllAsyncIclude()
        {
            return await DBContext.SystemUser
                                  .Include(a => a.SystemUserPermissions)
                                  .ToListAsync();
        }

        public async Task<SystemUser> GetByIDAsyncIclude(int id)
        {
            return await DBContext.SystemUser
                                  .Where(a => a.Id == id)
                                  .Include(a => a.SystemUserPermissions)
                                  .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteEntity(int id)
        {
            SystemUser data = await GetByIDAsync(id);
            if (data.CreatedBy == AppMainData.SeedData)
            {
                return false;
            }
            return true;
        }

        public new void DeleteEntity(List<SystemUser> entities)
        {
            foreach (SystemUser entity in entities)
            {
                DeleteEntity(entity);
            }
        }

        public new void DeleteEntity(SystemUser entity)
        {
            if (entity.CreatedBy != AppMainData.SeedData)
            {
                DBContext.Set<SystemUser>().Remove(entity);
            }
        }
    }
}
