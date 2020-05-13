using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity.AppModel
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الاسم بالكامل")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("رقم الجوال")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("الصوره")]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string ImageURL { get; set; }

        [DisplayName("المعرف")]
        public Guid Token { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("نسخة التطبيق")]
        public string AppVersion { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("إصدار الجهاز")]
        public string DeviceVersion { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("طراز الجهاز")]
        public string DeviceModel { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("رمز الإخطارات")]
        public string NotificationToken { get; set; }

        [DisplayName("التنشيط")]
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(Language))]
        [DisplayName(nameof(Language))]
        public int Fk_Language { get; set; }

        [DisplayName("اللغه")]
        public Language Language { get; set; }

        [DisplayName("المجموعات الخاصة")]
        public ICollection<Group> Groups { get; set; }

        [DisplayName("أعضاء المجموعة")]
        public ICollection<GroupMember> GroupMembers { get; set; }

        [DisplayName("رسائل المجموعه")]
        public ICollection<GroupMessage> GroupMessages { get; set; }

        [DisplayName("جهات اتصال الخاصة بي")]
        public ICollection<UserContact> MyUserContacts { get; set; }

        [DisplayName("أنا في جهات اتصال")]
        public ICollection<UserContact> MeInUserContacts { get; set; }
    }
}
