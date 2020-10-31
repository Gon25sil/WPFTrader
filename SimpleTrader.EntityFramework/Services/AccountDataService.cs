using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly SimpleTraderDbContextFactory simpleTraderDbContextFactory; //create always a new context due to thread-safety reasons
        private readonly NonQueryDataService<Account> nonQueryDataService; 
        public AccountDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            this.simpleTraderDbContextFactory = simpleTraderDbContextFactory;
            this.nonQueryDataService = new NonQueryDataService<Account>(simpleTraderDbContextFactory);

        }

        public async Task<Account> Create(Account entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(x => x.AccountHolder)
                    .Include(x=>x.AssetTransactions).FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                IEnumerable<Account> entity = await context.Accounts
                    .Include(x => x.AccountHolder)
                    .Include(x=>x.AssetTransactions).ToListAsync();
                return entity;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using(var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                Account account = await context.Accounts
                                .Include(x=> x.AccountHolder)
                                .Include(x => x.AssetTransactions)
                                .FirstOrDefaultAsync(x => x.AccountHolder.Email == email);
                return account;
                        
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                Account account = await context.Accounts
                                .Include(x => x.AccountHolder)
                                .Include(x => x.AssetTransactions)
                                .FirstOrDefaultAsync(x => x.AccountHolder.Username == username);
                return account;

            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }


    }
}
