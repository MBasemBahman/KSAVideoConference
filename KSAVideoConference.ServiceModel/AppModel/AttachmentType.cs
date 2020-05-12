using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class AttachmentTypeModel : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("الاسم")]
        public string Name { get; set; }

        [DisplayName("الملفات المرفقه")]
        public ICollection<AttachmentModel> Attachments { get; set; }
    }
}
