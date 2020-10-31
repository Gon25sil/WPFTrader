using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetStockRealTimePrice(string symbol)
        {
            string uri = "https://financialmodelingprep.com/api/v3/quote/" + symbol;
            string apiKey = "c5a2e53fae0669e13e1bc53f1a1a6f27";

            using (FinancialModelingPrepHttpClient httpClient = new FinancialModelingPrepHttpClient())
            {
                StockPriceResult stockPriceResult = await httpClient.GetAsync<StockPriceResult>($"{uri}?apikey={apiKey}");

                if (stockPriceResult == null)
                    throw new InvalidSymbolException("symbol");
                return stockPriceResult.Price;
            }
        }
    }
}
