using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class IGroupModel
    {
        public int Id { get; set; }

        public int Fk_Creator { get; set; }

        public bool IsActive { get; set; }

        public int MaxGroupCount { get; set; }

        public int MaxStreamCount { get; set; }

        public string Name { get; set; }

        public IFormFile UploudFile { get; set; }
    }

    public class GroupModel : BaseModel
    {
        public string Name { get; set; }

        public string SummaryMemberNames { get; set; }

        public string LogoURL { get; set; }

        public int MaxGroupCount { get; set; } = 100;

        public int MaxStreamCount { get; set; } = 10;

        public string SessionId { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsJoin { get; set; } = false;

        public bool IsOwner { get; set; } = false;

        public int Fk_Creator { get; set; }

        public UserModel Creator { get; set; }

        public ICollection<GroupMemberModel> GroupMembers { get; set; }

        public ICollection<GroupMessageModel> GroupMessages { get; set; }
    }
}
