using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.Repository.AppRepository
{
    public class AppStaticMessageRepository : AppBaseRepository<AppStaticMessage>, ILanguage<AppStaticMessage>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public AppStaticMessageRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public string Encode(string ErrorMessage)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return EncodeManager.Base64Encode(ErrorMessage);
            }
            return ErrorMessage;
        }

        public async Task<List<AppStaticMessage>> GetAllAsyncIclude()
        {
            return await DBContext.AppStaticMessage
                                  .Include(a => a.AppStaticMessageLangs)
                                  .ToListAsync();
        }
        public async Task<List<AppStaticMessage>> GetAllAsync(string CreatedBy)
        {
            return await DBContext.AppStaticMessage.Where(a => a.CreatedBy == CreatedBy)
                                  .Include(a => a.AppStaticMessageLangs)
                                  .ToListAsync();
        }

        public async Task<AppStaticMessage> GetByIDAsyncIclude(int id)
        {
            return await DBContext.AppStaticMessage
                                  .Where(a => a.Id == id)
                                  .Include(a => a.AppStaticMessageLangs)
                                  .FirstOrDefaultAsync();
        }

        public async Task<AppStaticMessage> GetByIDAsync(AppStaticMessage Source, int Fk_Language)
        {
            if (Fk_Language != (int)LanguageEnum.Arabic)
            {
                AppStaticMessageLang Data = await DBContext.AppStaticMessageLang
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

        public async Task<string> GetStaticMessage(int Id, int Fk_Language = (int)LanguageEnum.Arabic)
        {
            AppStaticMessage Source = await GetByIDAsync(Id);
            if (Fk_Language != (int)LanguageEnum.Arabic)
            {
                AppStaticMessageLang Data = await DBContext.AppStaticMessageLang
                                  .Where(a => a.Fk_Source == Source.Id)
                                  .Where(a => a.Fk_Language == Fk_Language)
                                  .FirstOrDefaultAsync();

                if (Data != null)
                {
                    _Mapper.Map(Data, Source);
                }
            }

            return Source.Value;
        }

        public async Task<List<AppStaticMessage>> GetAllAsync(int Fk_Language)
        {
            List<AppStaticMessage> Sources = await GetAllAsync();
            if (Fk_Language != (int)LanguageEnum.English)
            {
                Sources.ForEach(async Source => Source = await GetByIDAsync(Source, Fk_Language));
            }
            return Sources;
        }
    }
}
