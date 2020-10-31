using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory simpleTraderDbContextFactory; //create always a new context due to thread-safety reasons
        private readonly NonQueryDataService<T> nonQueryDataService;
        public GenericDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory, NonQueryDataService<T> nonQueryDataService)
        {
            this.simpleTraderDbContextFactory = simpleTraderDbContextFactory;
            this.nonQueryDataService = nonQueryDataService;
        }

        public async Task<T> Create(T entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);

        }

        public async Task<T> Get(int id)
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                IEnumerable<T> entity = await context.Set<T>().ToListAsync();
                return entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
