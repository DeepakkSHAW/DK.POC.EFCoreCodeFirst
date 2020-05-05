using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace DK.POC.EFCoreCodeFirst.DAL
{
    public class DataAccess : DbContext
    {
        private readonly SqlConnection _sqlConnection;
        public DbSet<Models.Products> Products { get; set; }

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
    }
}
