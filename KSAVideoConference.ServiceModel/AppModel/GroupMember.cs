namespace KSAVideoConference.ServiceModel.AppModel
{
    public class IGroupMemberModel
    {
        public int Id { get; set; }
        public int Fk_Group { get; set; }
        public int Fk_MemberType { get; set; }
        public int Fk_User { get; set; }
    }

    public class GroupMemberModel : BaseModel
    {
        public int Fk_User { get; set; }

        public UserModel User { get; set; }

        public int Fk_Group { get; set; }

        public GroupModel Group { get; set; }

        public int Fk_MemberType { get; set; }

        public MemberTypeModel MemberType { get; set; }
    }
}
