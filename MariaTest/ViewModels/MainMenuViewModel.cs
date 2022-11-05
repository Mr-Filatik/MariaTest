using MariaTestTask.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaTest.ViewModels
{
    public class MainMenuViewModel
    {
        public Action? CloseWindow { get; set; }

        private ButtonCommand? _openDispatcherCommand;
        public ButtonCommand OpenDispatcherCommand
        {
            get
            {
                return _openDispatcherCommand ??
                  (_openDispatcherCommand = new ButtonCommand(obj =>
                  {
                      DispatcherWindow window = new DispatcherWindow();
                      window.Show();
                      CloseWindow?.Invoke();
                  }));
            }
        }
    }
}
