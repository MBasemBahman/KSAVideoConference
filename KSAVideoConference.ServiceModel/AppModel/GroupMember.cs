using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class GroupMemberModel : BaseModel
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName("المستخدم")]
        public UserModel User { get; set; }

        [ForeignKey(nameof(Group))]
        [DisplayName(nameof(Group))]
        public int Fk_Group { get; set; }

        [DisplayName("المجموعه")]
        public GroupModel Group { get; set; }

        [ForeignKey(nameof(MemberType))]
        [DisplayName(nameof(MemberType))]
        public int Fk_MemberType { get; set; }

        [DisplayName("نوع المستخدم")]
        public MemberTypeModel MemberType { get; set; }

        [DisplayName("التنشيط")]
        public bool IsActive { get; set; } = true;
    }
}
