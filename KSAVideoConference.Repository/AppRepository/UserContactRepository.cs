using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.ServiceModel.AppModel;
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

        public User AddContact(IUserContactModel UserContact, User UserDB)
        {
            UserContact.Fk_User = UserDB.Id;
            if (!DBContext.UserContact.Any(a => a.Fk_User == UserContact.Fk_User && a.Fk_Contact == UserContact.Fk_Contact))
            {
                UserContact UserContactDB = new UserContact();
                _Mapper.Map(UserContact, UserContactDB);

                if (UserDB.MyUserContacts == null)
                {
                    UserDB.MyUserContacts = new List<UserContact>();
                }
                UserDB.MyUserContacts.Add(UserContactDB);
            }

            return UserDB;
        }
    }
}
