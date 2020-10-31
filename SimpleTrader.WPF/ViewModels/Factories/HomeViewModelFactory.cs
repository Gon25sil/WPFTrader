using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : ISimpleTraderViewModelFactory<HomeViewModel>
    {
        private readonly ISimpleTraderViewModelFactory<MajorIndexListingViewModel> majorListingFactory;

        public HomeViewModelFactory(ISimpleTraderViewModelFactory<MajorIndexListingViewModel> simpleTraderViewModelFactory)
        {
            this.majorListingFactory = simpleTraderViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(majorListingFactory.CreateViewModel());
        }
    }
}
