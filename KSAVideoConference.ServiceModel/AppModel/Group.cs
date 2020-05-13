using System.Collections.Generic;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public interface IGroupModel
    {
        public int Id { get; set; }
        int Fk_Creator { get; set; }
        bool IsActive { get; set; }
        int MaxGroupCount { get; set; }
        int MaxStreamCount { get; set; }
        string Name { get; set; }
    }

    public class GroupModel : BaseModel, IGroupModel
    {
        public string Name { get; set; }

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
