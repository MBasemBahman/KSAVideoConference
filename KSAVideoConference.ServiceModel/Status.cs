namespace KSAVideoConference.ServiceModel
{
    public class Status
    {
        public Status()
        {
        }

        public Status(bool Success)
        {
            this.Success = Success;
            ErrorMessage = null;
        }

        public bool Success { get; private set; } = false;

        public string ErrorMessage { get; set; } = "رسالة خطأ!";

        public string ExceptionMessage { get; set; }
    }
}
