using System;

namespace MariaTest.Models
{
    /// <summary>
    /// Class for describing plans and number of measurements
    /// </summary>
    public class MeasurementPlan
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            if (Date == default(DateTime))
            {
                return "";
            }
            string result = $"{Date.Day.ToString().PadLeft(2, '0')}.{Date.Month.ToString().PadLeft(2, '0')}.{Date.Year.ToString().PadLeft(2, '0')}";
            result += " ";
            result += (TimeInterval == TimeInterval.AllDay ? "" : TimeInterval switch
            {
                TimeInterval.From10To12 => "10-12",
                TimeInterval.From12To14 => "12-14",
                TimeInterval.From14To16 => "14-16",
                TimeInterval.From16To18 => "16-18",
                TimeInterval.From18To20 => "18-20",
                _ => ""
            });
            return result;
        }
    }

    /// <summary>
    /// Enumeration for setting sampling time intervals
    /// </summary>
    public enum TimeInterval
    {
        AllDay,
        From10To12,
        From12To14,
        From14To16,
        From16To18,
        From18To20
    }
}
