using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AuthModel
{
    public class AccessLevel : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("اسم مستوى الوصول")]
        public string Name { get; set; }

        public ICollection<SystemUserPermission> SystemUserPermissions { get; set; }
    }
}
