using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class MemberType : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("نوع المستخدم")]
        public string Name { get; set; }

        [DisplayName("اعضاء المجموعه")]
        public ICollection<GroupMember> GroupMembers { get; set; }
    }
}
