using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Context
{
   public class SalesWebMvcContext: DbContext
   {
      public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options): base(options)
      {
         Database.EnsureCreated();
      }

      public DbSet<Department> Department { get; set; } 
      public DbSet<Seller> Seller { get; set; }
      public DbSet<SaleRecord> SaleRecord { get; set; }
   }
}
