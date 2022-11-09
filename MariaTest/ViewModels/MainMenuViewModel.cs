using MariaTestTask.Comands;
using System;
using System.Windows;

namespace MariaTest.ViewModels
{
    /// <summary>
    /// ViewModel for MainMenuWindow
    /// </summary>
    public class MainMenuViewModel : ViewModel
    {
        #region Button Commands

        private ButtonCommand? _openDispatcherCommand;
        public ButtonCommand OpenDispatcherCommand
        {
            get
            {
                return _openDispatcherCommand ??
                  (_openDispatcherCommand = new ButtonCommand(obj =>
                  {
                      ((App)Application.Current).OpenDispatcherWindow(CloseWindow);
                      //((App)Application.Current).OpenWindow<MainMenuWindow, MainMenuViewModel>(closeWindow);
                  }));
            }
        }

        #endregion
    }
}
