namespace Bitukai.Models
{
    public class VideoCard: Component
    {
        public string ChipSet { get; set; }
        public string MemoryType { get; set; }
        public int MemoryGb { get; set; }
        public int CoreClockMhz { get; set; }
        public string Interface { get; set; }
    }
}
