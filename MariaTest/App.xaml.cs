using System;
using System.Windows;
using MariaTest.Data.Local;
using MariaTest.ViewModels;
using MariaTest.Data.Abstract;

namespace MariaTest
{
    /// <summary>
    /// Application main class
    /// </summary>
    public partial class App : Application
    {
        //Class derived from IDispatcherble for data access
        public IDispatcherble Context { get; init; }

        public App()
        {
            //Сreate any class derived from IDispatcherble for data access
            Context = new LocalData();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            OpenMainMenuWindow();
        }

        /// <summary>
        /// Method to open window (MainMenuWindow) with link to viewmodel (MainMenuViewModel)
        /// </summary>
        /// <param name="closeWindow">Action to close the window (default null)</param>
        public void OpenMainMenuWindow(Action? closeWindow = null)
        {
            OpenWindow<MainMenuWindow, MainMenuViewModel>(closeWindow);
        }

        /// <summary>
        /// Method to open window (DispatcherWindow) with link to viewmodel (DispatcherViewModel)
        /// </summary>
        /// <param name="closeWindow">Action to close the window (default null)</param>
        public void OpenDispatcherWindow(Action? closeWindow = null)
        {
            OpenWindow<DispatcherWindow, DispatcherViewModel>(closeWindow);
        }

        /// <summary>
        /// Generics method to open window with link to viewmodel
        /// </summary>
        /// <param name="closeWindow">Action to close the window (default null)</param>
        public void OpenWindow<TWindow, TViewModel>(Action? closeWindow = null)
            where TWindow : Window, new()
            where TViewModel : ViewModel, new()
        {
            TWindow window = new TWindow();
            TViewModel viewModel = new TViewModel();
            viewModel.CloseWindow = new Action(window.Close);
            window.DataContext = viewModel;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            closeWindow?.Invoke();
        }
    }
}
