using MariaTest.Data.Abstract;
using MariaTest.Models;
using MariaTestTask.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaTest.Data.Local
{
    public class LocalData : IDispatcherble
    {
        private List<Bid> _bids;
        private List<MeasurementPlan> _measurementPlans;

        public LocalData()
        {
            _measurementPlans = new List<MeasurementPlan>()
            {
                new MeasurementPlan(){ Id = 1, City = "Саратов", Date = new DateTime(2022, 11, 7), TimeInterval = TimeInterval.AllDay, Amount = 2 },
                new MeasurementPlan(){ Id = 2, City = "Саратов", Date = new DateTime(2022, 11, 8), TimeInterval = TimeInterval.AllDay, Amount = 2 },
                new MeasurementPlan(){ Id = 3, City = "Москва", Date = new DateTime(2022, 11, 7), TimeInterval = TimeInterval.From10To12, Amount = 2 },
                new MeasurementPlan(){ Id = 4, City = "Москва", Date = new DateTime(2022, 11, 7), TimeInterval = TimeInterval.From12To14, Amount = 2 },
            };
            _bids = new List<Bid>()
            {
                new Bid(){ Id = 1, City = "Саратов", Address = "ул. Б. Садовая, д. 104", FullName = "Филатов В.П.", Phone = "+7(937)021-16-53", MeasurementPlan = null },
                new Bid(){ Id = 2, City = "Саратов", Address = "ул. Б. Садовая, д. 103", FullName = "Филатов В.А.", Phone = "+7(937)021-17-53", MeasurementPlan = null },
                new Bid(){ Id = 3, City = "Саратов", Address = "ул. Б. Садовая, д. 105", FullName = "Филатов В.Р.", Phone = "+7(937)021-16-59", MeasurementPlan = null },
                new Bid(){ Id = 4, City = "Саратов", Address = "ул. Б. Садовая, д. 101", FullName = "Филатов В.B.", Phone = "+7(937)021-16-54", MeasurementPlan = null },
                new Bid(){ Id = 5, City = "Саратов", Address = "ул. Б. Садовая, д. 102", FullName = "Филатов В.C.", Phone = "+7(937)021-16-55", MeasurementPlan = _measurementPlans[0] },
                new Bid(){ Id = 6, City = "Самара", Address = "ул. Городская, д. 10", FullName = "Филатов В.Е.", Phone = "+7(937)021-16-58", MeasurementPlan = null },
                new Bid(){ Id = 7, City = "Москва", Address = "ул. Б. Горьковская, д. 1000", FullName = "Филатов В.Д.", Phone = "+7(937)021-16-56", MeasurementPlan = null },
                new Bid(){ Id = 8, City = "Москва", Address = "ул. Б. Горьковская, д. 1001", FullName = "Филатов В.Г.", Phone = "+7(937)021-16-57", MeasurementPlan = null }
            };
        }

        public LocalData(List<MeasurementPlan> measurementPlans, List<Bid> bids)
        {
            _measurementPlans = measurementPlans;
            _bids = bids;
        }

        public List<Bid> GetNewBids(bool onlyBlank = true)
        {
            List<Bid> bids = new List<Bid>();
            if (onlyBlank)
            {
                bids = _bids.Where(x => x.MeasurementPlan == null).ToList();
            }
            else
            {
                bids = _bids.Where(x => x.MeasurementPlan == null || x.MeasurementPlan?.Date > DateTime.Now).ToList();
            }
            return bids;
        }

        public Bid GetBidById(int id)
        {
            return _bids.FirstOrDefault(x => x.Id == id);
        }

        public MeasurementPlan GetMeasurementPlanById(int id)
        {
            return _measurementPlans.FirstOrDefault(x => x.Id == id);
        }

        public List<MeasurementPlanWithFreeCount> GetFreeMeasurementPlansByCity(string city)
        {
            List<MeasurementPlanWithFreeCount> result = new List<MeasurementPlanWithFreeCount>();
            List<MeasurementPlan> plans = _measurementPlans.Where(x => x.City == city).ToList();
            foreach (var item in plans)
            {
                int count = GetCountByMeasurementPlan(item);
                if (item.Amount > count)
                {
                    result.Add(new MeasurementPlanWithFreeCount()
                    {
                        MeasurementPlan = item,
                        Count = item.Amount - count
                    });
                }
            }
            return result;
        }

        public int GetCountByMeasurementPlan(MeasurementPlan plan)
        {
            if (plan == null) 
            {
                return 0;
            }
            return _bids.Where(x => x.MeasurementPlan == plan).ToList().Count;
        }

        public bool ChangeMeasurementPlanBid(int idBid, int idMeasurementPlan)
        {
            Bid bid = GetBidById(idBid);
            if (bid != null)
            {
                MeasurementPlan plan = GetMeasurementPlanById(idMeasurementPlan);
                if (plan != null)
                {
                    if (bid.City == plan.City)
                    {
                        bid.MeasurementPlan = plan;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DeleteMeasurementPlanBid(int idBid)
        {
            Bid bid = GetBidById(idBid);
            if (bid != null)
            {
                bid.MeasurementPlan = null;
                return true;
            }
            return false;
        }
    }
}
