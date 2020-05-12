using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity.AppModel
{
    public class UserContact : BaseModel
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName("المستخدم")]
        public User User { get; set; }

        [ForeignKey(nameof(Contact))]
        [DisplayName(nameof(Contact))]
        public int Fk_Contact { get; set; }

        [DisplayName("جهة اتصال")]
        public User Contact { get; set; }
    }
}
