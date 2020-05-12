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
    public class MemberTypeRepository : AppBaseRepository<MemberType>, ILookUp
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public MemberTypeRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<MemberType>> GetAllAsyncIclude()
        {
            return await DBContext.MemberType
                                  .Include(a => a.GroupMembers)
                                  .ToListAsync();
        }

        public async Task<MemberType> GetByIDAsyncIclude(int id)
        {
            return await DBContext.MemberType
                                  .Where(a => a.Id == id)
                                  .Include(a => a.GroupMembers)
                                  .FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> GetLookUpAsync()
        {
            List<MemberType> Data = await GetAllAsync();

            return Data.Select(a => new { a.Id, a.Name }).ToList<dynamic>();
        }
    }
}
