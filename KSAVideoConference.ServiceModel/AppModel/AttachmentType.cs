using System.Collections.Generic;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class AttachmentTypeModel : BaseModel
    {
        public string Name { get; set; }

        public ICollection<AttachmentModel> Attachments { get; set; }
    }
}
