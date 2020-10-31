using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDBContext>
    {
        public SimpleTraderDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDBContext>();
            options.UseSqlServer("Server=NB-PF0QPJ7M;Database=SimpletTraderDB;Trusted_Connection=True");
            return new SimpleTraderDBContext(options.Options);

        }
    }
}
