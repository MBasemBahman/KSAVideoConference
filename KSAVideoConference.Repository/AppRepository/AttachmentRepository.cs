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
    public class AttachmentRepository : AppBaseRepository<Attachment>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public AttachmentRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<Attachment>> GetAllAsyncIclude()
        {
            return await DBContext.Attachment
                                  .Include(a => a.GroupMessage)
                                  .ToListAsync();
        }

        public async Task<Attachment> GetByIDAsyncIclude(int id)
        {
            return await DBContext.Attachment
                                  .Where(a => a.Id == id)
                                  .Include(a => a.GroupMessage)
                                  .FirstOrDefaultAsync();
        }
    }
}
