using MariaTest.Models;

namespace MariaTestTask.Model
{
    /// <summary>
    /// Class for describing measurement requests
    /// </summary>
    public class Bid
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        //public int? MeasurementPlanId { get; set; }
        public MeasurementPlan? MeasurementPlan { get; set; }
    }
}
