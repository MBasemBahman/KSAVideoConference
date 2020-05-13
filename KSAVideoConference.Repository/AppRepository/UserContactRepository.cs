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
    public class UserContactRepository : AppBaseRepository<UserContact>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public UserContactRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<UserContact>> GetAllAsyncIclude()
        {
            return await DBContext.UserContact
                                  .Include(a => a.User)
                                  .Include(a => a.Contact)
                                  .ToListAsync();
        }

        public async Task<UserContact> GetByIDAsyncIclude(int id)
        {
            return await DBContext.UserContact
                                  .Where(a => a.Id == id)
                                  .Include(a => a.User)
                                  .Include(a => a.Contact)
                                  .FirstOrDefaultAsync();
        }
    }
}
