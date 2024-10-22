namespace WorkoutWasmPlanner.API.Models
{
    public class Supplement
    {

        public string SupplementName { get; set; }
        public string Dosage { get; set; } // E.g., "2 capsules"
        public string Frequency { get; set; } // E.g., "Daily", "Weekly"
        public string Description { get; set; }
    }
}
