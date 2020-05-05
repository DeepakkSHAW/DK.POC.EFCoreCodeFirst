using DK.POC.EFCoreCodeFirst.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.POC.EFCoreCodeFirst.DAL.Services
{
    public class CategorySrv : ICategorySrv
    {
        private DataAccess _ctx;
        private readonly SqlConnection _sqlConnection;
        public CategorySrv() { _ctx = new DataAccess(_sqlConnection); }
        public CategorySrv(SqlConnection sqlConnection)
        {
            _sqlConnection = new SqlConnection();
            _sqlConnection = sqlConnection;
            _ctx = new DataAccess(_sqlConnection);
        }

        public async Task<Categories> GetCategory(int Id)
        {
            var query = await _ctx.Categories
                 .Where(x => x.id == Id).FirstOrDefaultAsync();
            return query;
        }

        public async Task<List<Categories>> GetCategories()
        {
            try
            {
                var query = from c in _ctx.Categories select c;
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task NewCategotyAsync(Categories category)
        {
            _ctx.Add(category);
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> NewCategotiesAsync(List<Categories> categories)
        {
            int vResult = 0;
            try
            {
                foreach (var cat in categories)
                {
                    _ctx.Add(cat);
                }
                vResult= await _ctx.SaveChangesAsync();
                return vResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
