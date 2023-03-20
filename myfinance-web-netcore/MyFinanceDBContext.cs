using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;

namespace myfinance_web_netcore
{
    public class MyFinanceDBContext : DbContext
    {

        public MyFinanceDBContext(DbContextOptions<MyFinanceDBContext> options) : base(options) { }

        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // var connectionString = @"Server=127.0.0.1,1433;Database=myfinance;User Id=sa;Password=12345OHdf%e';encrypt=true;Trusted_Connection=True;TrustServerCertificate=True;";
            var connectionString = "Server=localhost,1433;Database=myfinance;User Id=sa;Password=12345OHdf%e;Encrypt=True;TrustServerCertificate=True";
            // var connectionString = @"
            // //   Server=127.0.0.1,1401;
            // //   Database=myfinance;
            // //   User Id=SA;
            // //   Password=12345OHdf%e";
            // var connectionString = @"Server=localhost;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}