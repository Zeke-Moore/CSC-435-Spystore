using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpyStore.DAL.EF;
using SpyStore.Models.Entities;

namespace SpyStore.EF
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {

        }
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-D2F2U58\SQLEXPRESS;Database=SpyStoreDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;",
                options => options.ExecutionStrategy(c=> new MyExecutionStrategy(c)));
            }
        }

        public DbSet<Category> Categories { get; set; }
    }
}
