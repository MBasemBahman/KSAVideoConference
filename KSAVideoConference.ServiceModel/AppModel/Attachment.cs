namespace KSAVideoConference.ServiceModel.AppModel
{
    public class AttachmentModel : BaseModel
    {
        public string AttachmentURL { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public long Length { get; set; } = 0;

        public GroupMessageModel GroupMessage { get; set; }
    }
}
