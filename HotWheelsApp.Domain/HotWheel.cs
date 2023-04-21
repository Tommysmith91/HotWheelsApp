namespace HotWheelsApp.Domain
{
    public class HotWheel
    {        
        public int Id { get; set;}
        public string CarCode { get; set; } 

        public string ModelName { get; set; }
        public int CollectionNumber { get; set; }
        public string Series { get; set; }
        public int SeriesNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}