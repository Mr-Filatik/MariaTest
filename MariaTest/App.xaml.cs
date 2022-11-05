using MariaTest.Data.Abstract;
using MariaTest.Data.Local;
using MariaTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MariaTest
{
    public partial class App : Application
    {
        public IDispatcherble Context { get; init; }

        public App()
        {
            //Сreate any class derived from IDispatcherble for data access
            Context = new LocalData();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainMenuWindow window = new MainMenuWindow();
            MainMenuViewModel viewModel = new MainMenuViewModel();
            viewModel.CloseWindow = new Action(window.Close);
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
