using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.PowerOData.Service.Models;

namespace Microsoft.PowerOData.Service.EF
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options, SqlConnection connection) : base(options)
        {
            _conn = connection;
        }

        private SqlConnection _conn;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);            
        }

        public DbSet<ProductEntityModel> product { get; set; }

    }
}