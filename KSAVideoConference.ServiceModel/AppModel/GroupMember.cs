namespace KSAVideoConference.ServiceModel.AppModel
{
    public interface IGroupMemberModel
    {
        int Id { get; set; }
        int Fk_Group { get; set; }
        int Fk_MemberType { get; set; }
        int Fk_User { get; set; }
    }

    public class GroupMemberModel : BaseModel, IGroupMemberModel
    {
        public int Fk_User { get; set; }

        public UserModel User { get; set; }

        public int Fk_Group { get; set; }

        public GroupModel Group { get; set; }

        public int Fk_MemberType { get; set; }

        public MemberTypeModel MemberType { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
