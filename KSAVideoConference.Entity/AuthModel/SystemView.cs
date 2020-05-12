using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AuthModel
{
    public class SystemView : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("اسم الصفحه")]
        public string Name { get; set; }

        public ICollection<SystemUserPermission> SystemUserPermissions { get; set; }
    }
}
