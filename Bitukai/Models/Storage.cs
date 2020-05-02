namespace Bitukai.Models
{
    public class Storage: Component
    {
        public int CapacityGb { get; set; }
        public string Type { get; set; }
        public int CacheMb { get; set; }
        public string FormFactor { get; set; }
        public string Interface { get; set; }
    }
}
