using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class IUserModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string AppVersion { get; set; }

        public string DeviceVersion { get; set; }

        public string DeviceModel { get; set; }

        public string NotificationToken { get; set; }

        public int Fk_Language { get; set; }

        public IFormFile ImageFile { get; set; }
    }

    public class UserModel : BaseModel
    {
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string ImageURL { get; set; }

        public Guid Token { get; set; }

        public string AppVersion { get; set; }

        public string DeviceVersion { get; set; }

        public string DeviceModel { get; set; }

        public string NotificationToken { get; set; }

        public int Fk_Language { get; set; }

        public LanguageModel Language { get; set; }

        public ICollection<GroupModel> Groups { get; set; }

        public ICollection<GroupMemberModel> GroupMembers { get; set; }

        public ICollection<GroupMessageModel> GroupMessages { get; set; }

        public ICollection<UserContactModel> MyUserContacts { get; set; }

        public ICollection<UserContactModel> MeInUserContacts { get; set; }
    }
}
