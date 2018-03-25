using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Models.Entities;

namespace SpyStore.DAL.EF
{
    public class MyExecutionStrategy : ExecutionStrategy
    {
        public MyExecutionStrategy(ExecutionStrategyDependencies context) :
        base(context, ExecutionStrategy.DefaultMaxRetryCount,
        ExecutionStrategy.DefaultMaxDelay)
        {

        }

        public MyExecutionStrategy(
        ExecutionStrategyDependencies context,
        int maxRetryCount,
        TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
        {

        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }

        public DbSet<Category> Categories { get; set; }
    }
}
