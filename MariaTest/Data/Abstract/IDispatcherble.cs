using MariaTest.Models;
using MariaTestTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaTest.Data.Abstract
{
    public interface IDispatcherble
    {
        List<Bid> GetNewBids(bool onlyBlank = true);
        Bid GetBidById(int id);
        MeasurementPlan GetMeasurementPlanById(int id);
        List<MeasurementPlanWithFreeCount> GetFreeMeasurementPlansByCity(string city);
        int GetCountByMeasurementPlan(MeasurementPlan plan);
        bool ChangeMeasurementPlanBid(int idBid, int idMeasurementPlan);
        bool DeleteMeasurementPlanBid(int idBid);
    }
}
