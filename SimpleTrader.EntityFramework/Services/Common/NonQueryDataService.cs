using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory simpleTraderDbContextFactory; //create always a new context due to thread-safety reasons

        public NonQueryDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            this.simpleTraderDbContextFactory = simpleTraderDbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                var newEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<T> Update(int id, T entity)
        {
            using (var context = simpleTraderDbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
