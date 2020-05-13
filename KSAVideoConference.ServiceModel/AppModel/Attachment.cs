namespace KSAVideoConference.ServiceModel.AppModel
{
    public class AttachmentModel : BaseModel
    {
        public string AttachmentURL { get; set; }

        public int Fk_AttachmentType { get; set; }

        public AttachmentTypeModel AttachmentType { get; set; }

        public GroupMessageModel GroupMessage { get; set; }
    }
}
