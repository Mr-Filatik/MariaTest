namespace MariaTest.Models
{
    /// <summary>
    /// Class for describing plans for measurements and the number of free places
    /// </summary>
    public class MeasurementPlanWithFreeCount
    {
        public MeasurementPlan MeasurementPlan { get; set; }
        public int Count { get; set; }
    }
}
