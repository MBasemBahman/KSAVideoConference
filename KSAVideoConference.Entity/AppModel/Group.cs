using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity.AppModel
{
    public class Group : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("اسم المجموعه")]
        public string Name { get; set; }

        [DisplayName("شعار المجموعه")]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string LogoURL { get; set; }

        [DisplayName("العدد الأقصى للمجموعة")]
        public int MaxGroupCount { get; set; } = 100;

        [DisplayName("العدد الأقصى للفيديو")]
        public int MaxStreamCount { get; set; } = 10;

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("معرف جلسة البث")]
        public string SessionId { get; set; }

        [DisplayName("التنشيط")]
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(Creator))]
        [DisplayName(nameof(Creator))]
        public int Fk_Creator { get; set; }

        [DisplayName("المنشئ")]
        public User Creator { get; set; }

        [DisplayName("أعضاء المجموعة")]
        public ICollection<GroupMember> GroupMembers { get; set; }

        [DisplayName("رسائل المجموعه")]
        public ICollection<GroupMessage> GroupMessages { get; set; }
    }
}
