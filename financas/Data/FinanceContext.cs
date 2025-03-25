using financas.Models;
using Microsoft.EntityFrameworkCore;

namespace financas.Data
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options){}

        public DbSet<FinancasModel> FinancasModel { get; set; }
    }
}