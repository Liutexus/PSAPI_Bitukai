namespace Bitukai.Models
{
    public class Motherboard: Component
    {
        public string FormFactor { get; set; }
        public string ChipSet { get; set; }
        public string MemoryType { get; set; }
        public byte MemorySlots { get; set; }
        public string CpuSocket { get; set; }
    }
}
