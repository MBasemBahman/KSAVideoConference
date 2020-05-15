using KSAVideoConference.CommonBL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class Attachment : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الملف المرفق")]
        public string AttachmentURL { get; set; } = AppMainData.DomainName;

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("نوع الملف")]
        public string Type { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("اسم الملف")]
        public string Name { get; set; }

        [DisplayName("حجم الملف")]
        public long Length { get; set; } = 0;

        [DisplayName("الرساله")]
        public GroupMessage GroupMessage { get; set; }
    }
}
