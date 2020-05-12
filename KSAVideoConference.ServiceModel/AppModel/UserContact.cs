using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class UserContactModel : BaseModel
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName("المستخدم")]
        public UserModel User { get; set; }

        [ForeignKey(nameof(Contact))]
        [DisplayName(nameof(Contact))]
        public int Fk_Contact { get; set; }

        [DisplayName("جهة اتصال")]
        public UserModel Contact { get; set; }
    }
}
