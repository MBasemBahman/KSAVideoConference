using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class MemberTypeModel : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("نوع المستخدم")]
        public string Name { get; set; }

        [DisplayName("اعضاء المجموعه")]
        public ICollection<GroupMemberModel> GroupMembers { get; set; }
    }
}
