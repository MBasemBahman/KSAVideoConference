using System.ComponentModel;
using KSAVideoConference.CommonBL;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity.AppModel
{
    public class GroupMember : BaseModel
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName("المستخدم")]
        public User User { get; set; }

        [ForeignKey(nameof(Group))]
        [DisplayName(nameof(Group))]
        public int Fk_Group { get; set; }

        [DisplayName("المجموعه")]
        public Group Group { get; set; }

        [ForeignKey(nameof(MemberType))]
        [DisplayName(nameof(MemberType))]
        public int Fk_MemberType { get; set; } = (int)EnumModel.MemberTypeEnum.Member; 

        [DisplayName("نوع المستخدم")]
        public MemberType MemberType { get; set; }

        [DisplayName("التنشيط")]
        public bool IsActive { get; set; } = true;
    }
}
