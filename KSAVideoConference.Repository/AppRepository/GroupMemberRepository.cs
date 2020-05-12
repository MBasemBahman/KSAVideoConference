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
    public class GroupMemberRepository : AppBaseRepository<GroupMember>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public GroupMemberRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<GroupMember>> GetAllAsyncIclude()
        {
            return await DBContext.GroupMember
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.MemberType)
                                  .ToListAsync();
        }

        public async Task<GroupMember> GetByIDAsyncIclude(int id)
        {
            return await DBContext.GroupMember
                                  .Where(a => a.Id == id)
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.MemberType)
                                  .FirstOrDefaultAsync();
        }
    }
}
