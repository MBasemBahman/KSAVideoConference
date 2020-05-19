namespace KSAVideoConference.AppAdmin.ViewModel
{
    public class ImageViewModel
    {
        public string LabelName { get; set; } = "Image Uploud";
        public string ImageName { get; set; } = "ImageFile";
    }

    public class MultiImageViewModel
    {
        public string Name { get; set; }
        public string UploudAction { get; set; }
        public int Id { get; set; }
    }
}
