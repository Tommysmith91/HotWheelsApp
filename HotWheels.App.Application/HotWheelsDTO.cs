namespace HotWheels.App.Application
{
    public sealed class HotWheelDTO
    {
        public int Id { get; set; }
        public string CarCode { get; set; } = String.Empty;

        public string ModelName { get; set; } = String.Empty;
        public int CollectionNumber { get; set; } = 0;
        public string Series { get; set; } = String.Empty;
        public int SeriesNumber { get; set; } = 0;
        public string ImageUrl { get; set; } = String.Empty;

    }
}