using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.Repository.AppRepository
{
    public class AttachmentTypeRepository : AppBaseRepository<AttachmentType>, ILookUp
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public AttachmentTypeRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<AttachmentType>> GetAllAsyncIclude()
        {
            return await DBContext.AttachmentType
                                  .Include(a => a.Attachments)
                                  .ToListAsync();
        }

        public async Task<AttachmentType> GetByIDAsyncIclude(int id)
        {
            return await DBContext.AttachmentType
                                  .Where(a => a.Id == id)
                                  .Include(a => a.Attachments)
                                  .FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> GetLookUpAsync()
        {
            List<AttachmentType> Data = await GetAllAsync();

            return Data.Select(a => new { a.Id, a.Name }).ToList<dynamic>();
        }
    }
}
