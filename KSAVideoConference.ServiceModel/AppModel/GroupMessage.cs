using Microsoft.AspNetCore.Http;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class IGroupMessageModel
    {
        public int Id { get; set; }

        public int Fk_Group { get; set; }

        public int Fk_User { get; set; }

        public string Message { get; set; }

        public IFormFile UploudFile { get; set; }
    }

    public class GroupMessageModel : BaseModel
    {
        public int Fk_User { get; set; }

        public UserModel User { get; set; }

        public int Fk_Group { get; set; }

        public GroupModel Group { get; set; }

        public string Message { get; set; }

        public int? Fk_Attachment { get; set; }

        public AttachmentModel Attachment { get; set; }
    }
}
