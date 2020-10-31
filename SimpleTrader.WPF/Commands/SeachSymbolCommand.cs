using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private readonly BuyViewModel buyViewModel;
        private readonly IStockPriceService stockPriceService;

        public SearchSymbolCommand(BuyViewModel buyViewModel, IStockPriceService stockPriceService)
        {
            this.buyViewModel = buyViewModel;
            this.stockPriceService = stockPriceService;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            stockPriceService.GetStockRealTimePrice(buyViewModel.Symbol).ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    buyViewModel.StockPrice = t.Result;
                    buyViewModel.SearchResultSymbol = buyViewModel.Symbol.ToUpper();
                }
                else
                {
                    MessageBox.Show(t.Exception.Message);
                }
            });
        }
    }
}
