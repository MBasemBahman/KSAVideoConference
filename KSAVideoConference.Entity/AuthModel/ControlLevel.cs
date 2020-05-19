using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AuthModel
{
    public class ControlLevel : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("اسم مستوى التحكم")]
        public string Name { get; set; }

        public ICollection<SystemUser> SystemUsers { get; set; }
    }
}
