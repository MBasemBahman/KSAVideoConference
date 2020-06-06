using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Group>> GetAllAsyncIclude(int id = 0, int Fk_User = 0, string CreatedBy = null)
        {
            return await DBContext.Group
                                  .Where(a => id == 0 ? true : a.Id == id)
                                  .Where(a => Fk_User == 0 ? true : a.Fk_Creator == Fk_User)
                                  .Where(a => string.IsNullOrEmpty(CreatedBy) ? true : a.CreatedBy == CreatedBy)
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
                                  .ThenInclude(a => a.User)
                                  .Include(a => a.GroupMessages)
                                  .ThenInclude(a => a.User)
                                  .FirstOrDefaultAsync();
        }

        public async Task<GroupModel> GetGroupProfile(int Id, int Fk_User)
        {
            GroupModel returnData = new GroupModel();
            Group GroupDB = await GetByIDAsyncIclude(Id);

            _Mapper.Map(GroupDB, returnData);

            returnData.IsJoin = true;

            if (GroupDB.Fk_Creator == Fk_User)
            {
                returnData.IsOwner = true;
            }

            returnData.Creator = new UserModel();
            _Mapper.Map(GroupDB.Creator, returnData.Creator);

            returnData.GroupMembers = new List<GroupMemberModel>();

            foreach (GroupMember item in GroupDB.GroupMembers)
            {
                GroupMemberModel item2 = new GroupMemberModel();

                _Mapper.Map(item, item2);

                item2.User = new UserModel();
                _Mapper.Map(item.User, item2.User);
                item2.MemberType = new MemberTypeModel();
                _Mapper.Map(item.MemberType, item2.MemberType);

                returnData.GroupMembers.Add(item2);
            }

            returnData.GroupMessages = new List<GroupMessageModel>();

            foreach (GroupMessage item in GroupDB.GroupMessages)
            {
                GroupMessageModel item2 = new GroupMessageModel();

                _Mapper.Map(item, item2);

                item2.User = new UserModel();
                _Mapper.Map(item.User, item2.User);

                returnData.GroupMessages.Add(item2);
            }

            return returnData;
        }

        public async Task UploudFile(Group Group, IFormFile File)
        {
            if (File != null)
            {
                ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                string FileURL = await ImgManager.UploudImageAsync(AppMainData.DomainName, Group.Id.ToString(), File, "Uploud/Group");

                if (!string.IsNullOrEmpty(FileURL))
                {
                    if (!string.IsNullOrEmpty(Group.LogoURL))
                    {
                        ImgManager.DeleteImage(Group.LogoURL, AppMainData.DomainName);
                    }
                    Group.LogoURL = FileURL;
                    UpdateEntity(Group);
                    await SaveAsync();
                }
            }
        }
    }
}
