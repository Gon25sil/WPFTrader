using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.Controls;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public INavigator Navigator { get; }

        private readonly IRootSimpleTraderViewModelFactory simpleTraderViewModelAbstractFactory;
        public UpdateCurrentViewModelCommand(INavigator navigator, IRootSimpleTraderViewModelFactory simpleTraderViewModelAbstractFactory)
        {
            Navigator = navigator;
            this.simpleTraderViewModelAbstractFactory = simpleTraderViewModelAbstractFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType view)
            {
               Navigator.CurrentViewModel = simpleTraderViewModelAbstractFactory.CreateViewModel(view);
            }
        }
    }
}
