using DK.POC.EFCoreCodeFirst.DAL.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task NewProductAsync(Products products)
        {
            await _ctx.Products.AddAsync(products);
        }

        public async Task<int> NewProductsAsync(List<Products> products)
        {
            int vResult = 0;
            try
            {
                foreach (var product in products)
                {
                    await _ctx.AddAsync(product);
                }
                vResult = await _ctx.SaveChangesAsync();
                return vResult;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
