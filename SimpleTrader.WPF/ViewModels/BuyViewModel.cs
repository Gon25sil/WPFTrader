using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionsServices;
using SimpleTrader.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);
        }

        private string symbol;
        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string searchResultSymbol = string.Empty;
        public string SearchResultSymbol
        {
            get
            {
                return searchResultSymbol;
            }
            set
            {
                searchResultSymbol = value;
                OnPropertyChanged(nameof(SearchResultSymbol));
            }
        }
        private double stockPrice;
        public double StockPrice
        {
            get
            {
                return stockPrice;
            }
            set
            {
                stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int amountOfShares;
        public int AmountOfShares
        {
            get
            {
                return amountOfShares;
            }
            set
            {
                amountOfShares = value;
                OnPropertyChanged(nameof(AmountOfShares));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice {
            get
            {
                return StockPrice * AmountOfShares;
            } 
        }

        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }
    }
}
