using Microsoft.Data.SqlClient;

namespace DK.POC.EFCoreCodeFirst.DAL.Services
{
    public class ProductSrv : IProductSrv
    {
        private DataAccess _ctx;
        private readonly SqlConnection _sqlConnection;
        public ProductSrv() { _ctx = new DataAccess(_sqlConnection); }
        public ProductSrv(SqlConnection sqlConnection)
        {
            _sqlConnection = new SqlConnection();
            _sqlConnection = sqlConnection;
            _ctx = new DataAccess(_sqlConnection);
        }
        public string GetName()
        {
            return "Testing done";
        }
    }
}
