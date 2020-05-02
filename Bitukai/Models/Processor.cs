namespace Bitukai.Models
{
    public class Processor: Component
    {
        public string Socket { get; set; }
        public double Tdp { get; set; }
        public byte CoreCount { get; set; }
        public float CoreClockGhz { get; set; }
        public string IntegratedGpu { get; set; }
    }
}
