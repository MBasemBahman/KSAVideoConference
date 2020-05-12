using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AttachmentType : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الاسم")]
        public string Name { get; set; }

        [DisplayName("الملفات المرفقه")]
        public ICollection<Attachment> Attachments { get; set; }
    }
}
