using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAVideoConference.Repository.AppRepository
{
    public class UserRepository : AppBaseRepository<User>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public UserRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<User>> GetAllAsyncIclude()
        {
            return await DBContext.User
                                  .Include(a => a.Groups)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.GroupMessages)
                                  .Include(a => a.MyUserContacts)
                                  .Include(a => a.MeInUserContacts)
                                  .ToListAsync();
        }

        public async Task<User> GetByIDAsyncIclude(int id)
        {
            return await DBContext.User
                                  .Where(a => a.Id == id)
                                  .Include(a => a.Groups)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.GroupMessages)
                                  .Include(a => a.MyUserContacts)
                                  .Include(a => a.MeInUserContacts)
                                  .FirstOrDefaultAsync();
        }
    }
}
