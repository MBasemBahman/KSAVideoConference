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
    public class AccessLevelRepository : AppBaseRepository<AccessLevel>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public AccessLevelRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<AccessLevel>> GetAllAsyncIclude()
        {
            return await DBContext.AccessLevel
                                  .Include(a => a.SystemUserPermissions)
                                  .ToListAsync();
        }

        public async Task<AccessLevel> GetByIDAsyncIclude(int id)
        {
            return await DBContext.AccessLevel
                                  .Where(a => a.Id == id)
                                  .Include(a => a.SystemUserPermissions)
                                  .FirstOrDefaultAsync();
        }

        public int GetAccessLevel(string ViewName)
        {
            return DBContext.SystemUserPermission
                            .Where(a => a.SystemUser.Email == AppMainData.Email)
                            .Where(a => a.SystemView.Name == ViewName)
                            .Select(a => a.Fk_AccessLevel)
                            .FirstOrDefault();
        }

        public async Task<bool> DeleteEntity(int id)
        {
            AccessLevel data = await GetByIDAsync(id);
            if (data.CreatedBy == AppMainData.SeedData)
            {
                return false;
            }
            return true;
        }

        public new void DeleteEntity(List<AccessLevel> entities)
        {
            foreach (AccessLevel entity in entities)
            {
                DeleteEntity(entity);
            }
        }

        public new void DeleteEntity(AccessLevel entity)
        {
            if (entity.CreatedBy != AppMainData.SeedData)
            {
                DBContext.Set<AccessLevel>().Remove(entity);
            }
        }
    }
}
