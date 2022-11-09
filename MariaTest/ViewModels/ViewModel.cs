using MariaTestTask.Comands;
using System;
using System.Windows;

namespace MariaTest.ViewModels
{
    /// <summary>
    /// Base class for ViewModels
    /// </summary>
    public class ViewModel
    {
        public Action? CloseWindow { get; set; }
    }
}
