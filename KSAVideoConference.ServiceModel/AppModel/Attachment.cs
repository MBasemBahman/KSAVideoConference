using KSAVideoConference.CommonBL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class AttachmentModel : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الملف المرفق")]
        public string AttachmentURL { get; set; }

        [ForeignKey(nameof(AttachmentType))]
        [DisplayName(nameof(AttachmentType))]
        public int Fk_AttachmentType { get; set; }

        [DisplayName("نوع الملف")]
        public AttachmentTypeModel AttachmentType { get; set; }

        [DisplayName("الرساله")]
        public GroupMessageModel GroupMessage { get; set; }
    }
}
