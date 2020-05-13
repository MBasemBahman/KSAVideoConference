using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AuthModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public int GetAccessLevel(string Email, string ViewName)
        {
            return DBContext.SystemUserPermission.Where(a => a.SystemUser.Email == Email && a.SystemView.Name == ViewName).Select(a => a.Fk_AccessLevel).FirstOrDefault();
        }

        public async Task<List<SystemUserPermission>> GetAllAsyncIclude()
        {
            return await DBContext.SystemUserPermission
                                  .Include(a => a.SystemUser)
                                  .Include(a => a.SystemView)
                                  .Include(a => a.AccessLevel)
                                  .Include(a => a.ControlLevel)
                                  .ToListAsync();
        }

        public async Task<SystemUserPermission> GetByIDAsyncIclude(int id)
        {
            return await DBContext.SystemUserPermission
                                  .Where(a => a.Id == id)
                                  .Include(a => a.SystemUser)
                                  .Include(a => a.SystemView)
                                  .Include(a => a.AccessLevel)
                                  .Include(a => a.ControlLevel)
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
