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
    public class ControlLevelRepository : AppBaseRepository<ControlLevel>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public ControlLevelRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<ControlLevel>> GetAllAsyncIclude()
        {
            return await DBContext.ControlLevel
                                  .Include(a => a.SystemUserPermissions)
                                  .ToListAsync();
        }

        public async Task<ControlLevel> GetByIDAsyncIclude(int id)
        {
            return await DBContext.ControlLevel
                                  .Where(a => a.Id == id)
                                  .Include(a => a.SystemUserPermissions)
                                  .FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteEntity(int id)
        {
            ControlLevel data = await GetByIDAsync(id);
            if (data.CreatedBy == AppMainData.SeedData)
            {
                return false;
            }
            return true;
        }

        public new void DeleteEntity(List<ControlLevel> entities)
        {
            foreach (ControlLevel entity in entities)
            {
                DeleteEntity(entity);
            }
        }

        public new void DeleteEntity(ControlLevel entity)
        {
            if (entity.CreatedBy != AppMainData.SeedData)
            {
                DBContext.Set<ControlLevel>().Remove(entity);
            }
        }
    }
}
