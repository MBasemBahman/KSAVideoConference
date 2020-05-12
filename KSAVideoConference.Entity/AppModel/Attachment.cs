using KSAVideoConference.CommonBL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity.AppModel
{
    public class Attachment : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الملف المرفق")]
        public string AttachmentURL { get; set; } = AppMainData.DomainName;

        [ForeignKey(nameof(AttachmentType))]
        [DisplayName(nameof(AttachmentType))]
        public int Fk_AttachmentType { get; set; }

        [DisplayName("نوع الملف")]
        public AttachmentType AttachmentType { get; set; }

        [DisplayName("الرساله")]
        public GroupMessage GroupMessage { get; set; }
    }
}
