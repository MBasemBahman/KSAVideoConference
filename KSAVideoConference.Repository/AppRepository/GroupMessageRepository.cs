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
    public class GroupMessageRepository : AppBaseRepository<GroupMessage>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public GroupMessageRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<GroupMessage>> GetAllAsyncIclude()
        {
            return await DBContext.GroupMessage
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.Attachment)
                                  .ToListAsync();
        }

        public async Task<GroupMessage> GetByIDAsyncIclude(int id)
        {
            return await DBContext.GroupMessage
                                  .Where(a => a.Id == id)
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.Attachment)
                                  .FirstOrDefaultAsync();
        }
    }
}
