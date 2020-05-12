using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AuthModel
{
    public class SystemUser : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("البريد الالكتروني")]
        [DataType(DataType.EmailAddress,ErrorMessage = "البريد الالكتروني مكتوب بشكل خاطيء")]
        [EmailAddress(ErrorMessage = "البريد الالكتروني مكتوب بشكل خاطيء")]
        public string Email { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الرقم السري")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الاسم بالكامل")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("المسمي الوظيفي")]
        public string JopTitle { get; set; }

        [DisplayName("التنشيط")]
        public bool IsActive { get; set; } = true;

        public ICollection<SystemUserPermission> SystemUserPermissions { get; set; }
    }
}
