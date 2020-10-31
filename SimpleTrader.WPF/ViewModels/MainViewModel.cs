using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
        }

        public INavigator Navigator { get; set; }
    }
}
