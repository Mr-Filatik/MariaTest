using MariaTest.Models;
using MariaTestTask.Model;
using System.Collections.Generic;

namespace MariaTest.Data.Abstract
{
    /// <summary>
    /// Data access interface
    /// </summary>
    public interface IDispatcherble
    {
        /// <summary>
        /// Method for receiving measurement requests
        /// </summary>
        /// <param name="onlyBlank">Display only measurements without dates</param>
        /// <param name="withOld">Include old measurement requests</param>
        /// <returns>List of applications for measurements</returns>
        List<Bid> GetBids(bool onlyBlank = true, bool withOld = false);
        /// <summary>
        /// Method for getting a specific measurement request by ID
        /// </summary>
        /// <param name="id">Measurement request ID</param>
        /// <returns>Measurement request or null</returns>
        Bid GetBidById(int id);
        /// <summary>
        /// Method for getting plan by ID
        /// </summary>
        /// <param name="id">Measurement request ID</param>
        /// <returns>Measurement request</returns>
        MeasurementPlan GetMeasurementPlanById(int id);
        /// <summary>
        /// Method for obtaining a list of measurements with a quantity
        /// </summary>
        /// <param name="city">City</param>
        /// <returns>List of measurements with quantity</returns>
        List<MeasurementPlanWithFreeCount> GetFreeMeasurementPlansByCity(string city);
        /// <summary>
        /// Method for counting the number of free plans on a date
        /// </summary>
        /// <param name="plan">Measurement plan</param>
        /// <returns>Number of free plans</returns>
        int GetCountByMeasurementPlan(MeasurementPlan plan);
        /// <summary>
        /// Method for changing the measurement date
        /// </summary>
        /// <param name="idBid">Measurement request ID</param>
        /// <param name="idMeasurementPlan">Plan ID</param>
        /// <returns>Has there been a change or not</returns>
        bool ChangeMeasurementPlanBid(int idBid, int idMeasurementPlan);
        /// <summary>
        /// Method for deleting measurement date
        /// </summary>
        /// <param name="idBid">Measurement request ID</param>
        /// <returns>Deletion happened or not</returns>
        bool DeleteMeasurementPlanBid(int idBid);
    }
}
