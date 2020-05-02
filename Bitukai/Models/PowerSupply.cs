using Bitukai.Models.Enums;

namespace Bitukai.Models
{
    public class PowerSupply: Component
    {
        public string FormFactor { get; set; }
        public int Wattage { get; set; }
        public string Efficiency { get; set; }
        public PSUModularity Modularity { get; set; }
    }
}
