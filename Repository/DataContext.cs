using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManagementMVC.Models;

namespace StockManagementMVC.Repository
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ProductModel> Products { get; set; }

        public DbSet<WarehouseTransactionModel> WarehouseTransactions { get; set; }

        public DbSet<SupplierModel> Supplier { get; set; }
    }
}
