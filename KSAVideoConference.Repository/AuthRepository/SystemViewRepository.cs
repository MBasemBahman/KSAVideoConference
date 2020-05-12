using KSAVideoConference.DAL;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.Entity.AuthModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace KSAVideoConference.Repository.AuthRepository
{
    public class SystemViewRepository : AppBaseRepository<SystemView>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public SystemViewRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public List<SystemView> GetSystemViews(string Email, int Fk_AccessLevel = 0)
        {
            return DBContext.SystemUserPermission
                            .Where(a => a.SystemUser.Email == Email)
                            .Where(a => (Fk_AccessLevel == 0) ? true : a.Fk_AccessLevel == Fk_AccessLevel)
                            .Select(a => a.SystemView)
                            .ToList();
        }

        public async Task<List<SystemView>> GetAllAsyncIclude()
        {
            return await DBContext.SystemView
                                  .Include(a => a.SystemUserPermissions)
                                  .ToListAsync();
        }

        public async Task<SystemView> GetByIDAsyncIclude(int id)
        {
            return await DBContext.SystemView
                                  .Where(a => a.Id == id)
                                  .Include(a => a.SystemUserPermissions)
                                  .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteEntity(int id)
        {
            SystemView data = await GetByIDAsync(id);
            if (data.CreatedBy == AppMainData.SeedData)
            {
                return false;
            }
            return true;
        }

        public new void DeleteEntity(List<SystemView> entities)
        {
            foreach (SystemView entity in entities)
            {
                DeleteEntity(entity);
            }
        }

        public new void DeleteEntity(SystemView entity)
        {
            if (entity.CreatedBy != AppMainData.SeedData)
            {
                DBContext.Set<SystemView>().Remove(entity);
            }
        }
    }
}
