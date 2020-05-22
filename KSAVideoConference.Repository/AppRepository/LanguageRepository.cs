using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.Repository.AppRepository
{
    public class LanguageRepository : AppBaseRepository<Language>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public LanguageRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<Language>> GetAllAsyncIclude()
        {
            return await DBContext.Language
                                  .Include(a => a.AppStaticMessageLangs)
                                  .Include(a => a.AppStaticWordLangs)
                                  .ToListAsync();
        }

        public async Task<Language> GetByIDAsyncIclude(int id)
        {
            return await DBContext.Language
                                  .Where(a => a.Id == id)
                                  .Include(a => a.AppStaticMessageLangs)
                                  .Include(a => a.AppStaticWordLangs)
                                  .FirstOrDefaultAsync();
        }
        public async Task<List<Language>> GetAllAsync(string CreatedBy)
        {
            return await DBContext.Language.Where(a => a.CreatedBy == CreatedBy)
                                  .ToListAsync();
        }
        public async Task<bool> DeleteEntity(int id)
        {
            Language data = await GetByIDAsync(id);
            if (data.CreatedBy == AppMainData.SeedData)
            {
                return false;
            }
            return true;
        }

        public new void DeleteEntity(List<Language> entities)
        {
            foreach (Language entity in entities)
            {
                DeleteEntity(entity);
            }
        }

        public new void DeleteEntity(Language entity)
        {
            if (entity.CreatedBy != AppMainData.SeedData)
            {
                DBContext.Set<Language>().Remove(entity);
            }
        }
    }
}
