namespace KSAVideoConference.ServiceModel
{
    public class Paging
    {
        private const int _maxSize = 20;
        private int _pageSize = 10;

        /// <summary>
        /// PageNumber = 1
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// PageSize = 10, maxSize = 20
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxSize) ? _maxSize : value;
        }

        public string OrderBy { get; set; } = "order";
    }
}
