using DK.POC.EFCoreCodeFirst.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace DK.POC.EFCoreCodeFirst.DAL
{
    public class DataAccess : DbContext
    {
        private readonly SqlConnection _sqlConnection;
        public virtual DbSet<Models.Products> Products { get; set; }
        public virtual DbSet<Models.Categories> Categories { get; set; }
        public DataAccess()
        {
        }
        public DataAccess(SqlConnection sqlConnection)
        {
            _sqlConnection = new SqlConnection();
            _sqlConnection = sqlConnection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_sqlConnection == null)
                {
                    optionsBuilder.UseSqlServer(@"Data Source=5GGWLQ2\SQLEXPRESS;Initial Catalog=CodeFirstDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    //optionsBuilder.UseSqlServer("Data Source=CIT-U-SC16-SQL2\\RECORDSMGMT;Initial Catalog=SystemIntegrationDB;Integrated Security=True;");
                }
                else
                {
                    optionsBuilder.UseSqlServer(_sqlConnection.ConnectionString);
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                // Set key for entity, may not required since Data Model has key attribute
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Products>()
                .HasOne(e => e.Categories)
                .WithMany(c => c.Products);

            modelBuilder.Entity<Categories>()
               .HasMany(c => c.Products)
               .WithOne(e => e.Categories);

        }
    }
}
