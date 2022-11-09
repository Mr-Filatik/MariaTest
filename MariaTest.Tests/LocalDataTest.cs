using MariaTest.Data.Abstract;
using MariaTest.Data.Local;
using MariaTest.Models;
using MariaTestTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MariaTest.Tests
{
    /// <summary>
    /// Class for testing data access methods
    /// </summary>
    public class LocalDataTest
    {
        [Fact]
        public void GetNewBidsResult()
        {
            IDispatcherble context = new LocalData();
            List<Bid> bids = null;

            bids = context.GetBids(true);

            Assert.NotNull(bids);

            bids = context.GetBids(false, false);

            Assert.NotNull(bids);

            bids = context.GetBids(false, true);

            Assert.NotNull(bids);
        }

        [Fact]
        public void GetBidByIdResult()
        {
            IDispatcherble context = new LocalData();
            Bid bid = null;

            Bid testBid = new Bid() { Id = 1 };
            bid = context.GetBidById(1);

            Assert.Equal(testBid.Id, bid.Id);

            bid = context.GetBidById(-1);

            Assert.Null(bid);
        }

        [Fact]
        public void GetMeasurementPlanByIdResult()
        {
            IDispatcherble context = new LocalData();
            MeasurementPlan plan = null;

            MeasurementPlan testPlan = new MeasurementPlan() { Id = 1 };
            plan = context.GetMeasurementPlanById(1);

            Assert.Equal(testPlan.Id, plan.Id);

            plan = context.GetMeasurementPlanById(-1);

            Assert.Null(plan);
        }

        [Fact]
        public void GetFreeMeasurementPlansByCityResult()
        {
            IDispatcherble context = new LocalData();
            List<MeasurementPlanWithFreeCount> plans = null;

            plans = context.GetFreeMeasurementPlansByCity("Саратов");

            Assert.NotNull(plans);
            Assert.NotEmpty(plans);

            plans = context.GetFreeMeasurementPlansByCity("Серпухов");

            Assert.NotNull(plans);
            Assert.Empty(plans);

            plans = context.GetFreeMeasurementPlansByCity(null);

            Assert.NotNull(plans);
            Assert.Empty(plans);
        }

        [Fact]
        public void GetCountByMeasurementPlanResult()
        {
            IDispatcherble context = new LocalData();
            MeasurementPlan plan = null;
            int number = 0;

            number = context.GetCountByMeasurementPlan(plan);

            Assert.Equal(0, number);

            plan = context.GetMeasurementPlanById(1);
            number = context.GetCountByMeasurementPlan(plan);

            Assert.NotEqual(0, number);
        }

        [Fact]
        public void ChangeMeasurementPlanBidResult()
        {
            IDispatcherble context = new LocalData();
            bool result = false;

            result = context.ChangeMeasurementPlanBid(-1, -4);

            Assert.False(result);

            result = context.ChangeMeasurementPlanBid(-1, 1);

            Assert.False(result);

            result = context.ChangeMeasurementPlanBid(2, -1);

            Assert.False(result);

            result = context.ChangeMeasurementPlanBid(1, 1);

            Assert.True(result);
        }

        [Fact]
        public void DeleteMeasurementPlanBidResult()
        {
            IDispatcherble context = new LocalData();
            bool result = false;

            result = context.DeleteMeasurementPlanBid(-1);

            Assert.False(result);

            result = context.DeleteMeasurementPlanBid(1);

            Assert.True(result);
        }
    }
}
