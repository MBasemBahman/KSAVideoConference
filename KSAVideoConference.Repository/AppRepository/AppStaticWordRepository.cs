using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.Repository.AppRepository
{
    public class AppStaticWordRepository : AppBaseRepository<AppStaticWord>, ILanguage<AppStaticWord>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public AppStaticWordRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<AppStaticWord>> GetAllAsyncIclude()
        {
            return await DBContext.AppStaticWord
                                  .Include(a => a.AppStaticWordLangs)
                                  .ToListAsync();
        }

        public async Task<AppStaticWord> GetByIDAsyncIclude(int id)
        {
            return await DBContext.AppStaticWord
                                  .Where(a => a.Id == id)
                                  .Include(a => a.AppStaticWordLangs)
                                  .FirstOrDefaultAsync();
        }

        public async Task<AppStaticWord> GetByIDAsync(AppStaticWord Source, int Fk_Language)
        {
            if (Fk_Language != (int)LanguageEnum.English)
            {
                AppStaticWordLang Data = await DBContext.AppStaticWordLang
                                  .Where(a => a.Fk_Source == Source.Id)
                                  .Where(a => a.Fk_Language == Fk_Language)
                                  .FirstOrDefaultAsync();

                if (Data != null)
                {
                    _Mapper.Map(Data, Source);
                }
            }

            return Source;
        }

        public async Task<List<AppStaticWord>> GetAllAsync(int Fk_Language)
        {
            List<AppStaticWord> Sources = await GetAllAsync();
            if (Fk_Language != (int)LanguageEnum.English)
            {
                Sources.ForEach(async Source => Source = await GetByIDAsync(Source, Fk_Language));
            }
            return Sources;
        }
    }
}
