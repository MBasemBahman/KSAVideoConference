using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<User>> GetAllAsyncIclude(int id)
        {
            return await DBContext.User
                                  .Where(a=>a.Id != id)
                                  .Include(a => a.Groups)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.GroupMessages)
                                  .Include(a => a.MyUserContacts)
                                  .Include(a => a.MeInUserContacts)
                                  .ToListAsync();
        }
        public async Task<List<User>> GetAllAsyncIclude()
        {
            return await DBContext.User
                                  .Include(a => a.Groups)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.Language)
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
                                  .Include(a => a.Language)
                                  .Include(a => a.GroupMembers)
                                  .Include(a => a.GroupMessages)
                                  .Include(a => a.MyUserContacts)
                                  .Include(a => a.MeInUserContacts)
                                  .FirstOrDefaultAsync();
        }

        public async Task<User> GetByTokenAsync(Guid Token)
        {
            return await DBContext.User
                                  .Where(a => a.Token == Token)
                                  .FirstOrDefaultAsync();
        }

        public async Task<User> GetByPhoneAsync(string Phone)
        {
            return await DBContext.User
                                  .Where(a => a.Phone == Phone)
                                  .FirstOrDefaultAsync();
        }

        public async Task<UserModel> GetUserProfile(int Id)
        {
            UserModel returnData = new UserModel();
            User UserDB = await GetByIDAsyncIclude(Id);
            _Mapper.Map(UserDB, returnData);

            return returnData;
        }

        public async Task UploudFile(User User, IFormFile File)
        {
            if (File != null)
            {
                ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                string FileURL = await ImgManager.UploudImageAsync(AppMainData.DomainName, User.Id.ToString(), File, "Uploud\\User");

                if (!string.IsNullOrEmpty(FileURL))
                {
                    if (!string.IsNullOrEmpty(User.ImageURL))
                    {
                        ImgManager.DeleteImage(User.ImageURL, AppMainData.DomainName);
                    }
                    User.ImageURL = FileURL;
                    UpdateEntity(User);
                    await SaveAsync();
                }
            }
        }
    }
}
