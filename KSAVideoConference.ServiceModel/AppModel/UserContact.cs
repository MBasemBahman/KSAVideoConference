namespace KSAVideoConference.ServiceModel.AppModel
{
    public class IUserContactModel
    {
        public int Id { get; set; }
        public int Fk_Contact { get; set; }
        public int Fk_User { get; set; }
    }

    public class UserContactModel : BaseModel
    {
        public int Fk_User { get; set; }

        public UserModel User { get; set; }

        public int Fk_Contact { get; set; }

        public UserModel Contact { get; set; }
    }
}
