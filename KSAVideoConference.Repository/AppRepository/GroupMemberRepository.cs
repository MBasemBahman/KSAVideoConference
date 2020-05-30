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
    public class GroupMemberRepository : AppBaseRepository<GroupMember>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public GroupMemberRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<GroupMember>> GetAllAsyncIclude(int Fk_Group = 0, int Fk_User = 0, string CreatedBy = null)
        {
            return await DBContext.GroupMember
                                  .Where(a => string.IsNullOrEmpty(CreatedBy) || a.CreatedBy == CreatedBy)
                                  .Where(a => Fk_Group == 0 || a.Fk_Group == Fk_Group)
                                  .Where(a => Fk_User == 0 || a.Fk_User == Fk_User)
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

        public async Task<bool> IsAdmin(int Fk_Group, int Fk_User)
        {
            if (await DBContext.Group.AnyAsync(a => a.Id == Fk_Group && a.Fk_Creator == Fk_User))
            {
                return true;
            }
            if (await DBContext.GroupMember.AnyAsync(a => a.Fk_Group == Fk_Group && a.Fk_User == Fk_User && a.Fk_MemberType != (int)MemberTypeEnum.Member))
            {
                return true;
            }

            return false;
        }
    }
}
