namespace Bitukai.Models
{
    public class Ram: Component
    {
        public int CapacityGb { get; set; }
        public byte ModuleCount { get; set; }
        public string DdrType { get; set; }
        public int SpeedMhz { get; set; }
        public int CasLatency { get; set; }
        public string Type { get; set; }
    }
}
