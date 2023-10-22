using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace IngaDev.Infra.Contexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext([NotNullAttribute] DbContextOptions options) : base(options) 
        {
                        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
