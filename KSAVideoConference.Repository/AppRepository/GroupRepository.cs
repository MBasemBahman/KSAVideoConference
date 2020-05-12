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
    public class GroupRepository : AppBaseRepository<Group>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public GroupRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<Group>> GetAllAsyncIclude()
        {
            return await DBContext.Group
                                  .Include(a => a.Creator)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.GroupMessages)
                                  .ToListAsync();
        }

        public async Task<Group> GetByIDAsyncIclude(int id)
        {
            return await DBContext.Group
                                  .Where(a => a.Id == id)
                                  .Include(a => a.Creator)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.GroupMessages)
                                  .FirstOrDefaultAsync();
        }
    }
}
