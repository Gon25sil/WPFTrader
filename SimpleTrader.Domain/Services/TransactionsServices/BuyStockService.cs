using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionsServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService stockPriceService;
        private readonly IDataService<Account> accountService;
        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            this.stockPriceService = stockPriceService;
            this.accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await stockPriceService.GetStockRealTimePrice(symbol);

            double transactionPrice = shares * stockPrice;

            if (transactionPrice > buyer.Balance)
                throw new InsuficientBalanceException(buyer.Balance, stockPrice);

            AssetTransaction assetTransaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                IsPurchase = true,
                Shares = shares
            };

            buyer.AssetTransactions.Add(assetTransaction);
            buyer.Balance -= transactionPrice;

            await accountService.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}
