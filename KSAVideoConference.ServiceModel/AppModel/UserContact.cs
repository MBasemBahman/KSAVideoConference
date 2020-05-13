namespace KSAVideoConference.ServiceModel.AppModel
{
    public interface IUserContactModel
    {
        int Id { get; set; }
        int Fk_Contact { get; set; }
        int Fk_User { get; set; }
    }

    public class UserContactModel : BaseModel, IUserContactModel
    {
        public int Fk_User { get; set; }

        public UserModel User { get; set; }

        public int Fk_Contact { get; set; }

        public UserModel Contact { get; set; }
    }
}
