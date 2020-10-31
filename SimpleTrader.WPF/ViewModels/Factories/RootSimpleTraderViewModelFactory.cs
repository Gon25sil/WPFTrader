using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class RootSimpleTraderViewModelFactory : IRootSimpleTraderViewModelFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory;
        private readonly BuyViewModel buyViewModel;

        public RootSimpleTraderViewModelFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,
            ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
            BuyViewModel buyViewModel)
        {
            this.homeViewModelFactory = homeViewModelFactory;
            this.portfolioViewModelFactory = portfolioViewModelFactory;
            this.buyViewModel = buyViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return portfolioViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return buyViewModel;
                default:
                    throw new ArgumentException("No view model defined for the view specified.");
            }
        }
    }
}
