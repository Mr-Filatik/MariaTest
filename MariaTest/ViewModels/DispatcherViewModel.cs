using MariaTest.Data.Abstract;
using MariaTest.Models;
using MariaTestTask.Comands;
using MariaTestTask.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

namespace MariaTest.ViewModels
{
    /// <summary>
    /// ViewModel for DispatcherWindow
    /// </summary>
    public class DispatcherViewModel : ViewModel, INotifyPropertyChanged
    {
        public IDispatcherble Context { get; init; }

        public DispatcherViewModel()
        {
            Context = ((App)Application.Current).Context;
            OnlyFreeBids = true;
            WithOldBids = false;
        }

        #region Properties for display data

        private bool _onlyFreeBids;
        public bool OnlyFreeBids
        {
            get
            {
                return _onlyFreeBids;
            }
            set
            {
                _onlyFreeBids = value;
                RefreshData();
                OnPropertyChanged("OnlyFreeBids");
            }
        }

        private bool _withOldBids;
        public bool WithOldBids
        {
            get
            {
                return _withOldBids;
            }
            set
            {
                _withOldBids = value;
                RefreshData();
                OnPropertyChanged("WithOldBids");
            }
        }

        private List<Bid> _bids;
        public List<Bid> Bids
        {
            get
            {
                return _bids;
            }
            set
            {
                _bids = value;
                OnPropertyChanged("Bids");
            }
        }

        private Bid? _selectBid;
        public Bid? SelectBid
        {
            get
            {
                return _selectBid;
            }
            set
            {
                _selectBid = value;
                if (value != null)
                {
                    MeasurementPlans = GetMeasurementPlans();
                }
                OnPropertyChanged("SelectBid");
            }
        }

        private List<MeasurementPlanWithFreeCount> _measurementPlans;
        public List<MeasurementPlanWithFreeCount> MeasurementPlans
        {
            get
            {
                return _measurementPlans;
            }
            set
            {
                _measurementPlans = value;
                OnPropertyChanged("MeasurementPlans");
            }
        }

        private MeasurementPlanWithFreeCount _newMeasurementPlan;
        public MeasurementPlanWithFreeCount NewMeasurementPlan
        {
            get
            {
                return _newMeasurementPlan;
            }
            set
            {
                _newMeasurementPlan = value;
                OnPropertyChanged("NewMeasurementPlan");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Button Commands

        private ButtonCommand? _saveCommand;
        public ButtonCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                  (_saveCommand = new ButtonCommand(obj =>
                  {
                      if (SelectBid != null && NewMeasurementPlan != null) 
                      {
                          Context.ChangeMeasurementPlanBid(SelectBid.Id, NewMeasurementPlan.MeasurementPlan.Id);
                          RefreshData();
                      }
                  }));
            }
        }

        private ButtonCommand? _deleteCommand;
        public ButtonCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                  (_deleteCommand = new ButtonCommand(obj =>
                  {
                      if (SelectBid != null)
                      {
                          Context.DeleteMeasurementPlanBid(SelectBid.Id);
                          RefreshData();
                      }
                  }));
            }
        }

        private ButtonCommand? _closeWindowCommand;
        public ButtonCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ??
                  (_closeWindowCommand = new ButtonCommand(obj =>
                  {
                      ((App)Application.Current).OpenMainMenuWindow(CloseWindow);
                      //((App)Application.Current).OpenWindow<DispatcherWindow, DispatcherViewModel>(CloseWindow);
                  }));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method for refresh data from Context
        /// </summary>
        public void RefreshData()
        {
            Bids = Context.GetBids(OnlyFreeBids, WithOldBids);
            SelectBid = null;
            NewMeasurementPlan = null;
        }

        /// <summary>
        /// Method for obtaining measurement plans for a selected city
        /// </summary>
        /// <returns>List of measurement plans with the number of free</returns>
        public List<MeasurementPlanWithFreeCount> GetMeasurementPlans()
        {
            if (SelectBid != null)
            {
                return Context.GetFreeMeasurementPlansByCity(SelectBid.City);
            }
            return new List<MeasurementPlanWithFreeCount>();
        }

        #endregion
    }
}
