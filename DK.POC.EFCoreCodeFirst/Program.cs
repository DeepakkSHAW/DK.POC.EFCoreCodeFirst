using DK.POC.EFCoreCodeFirst.DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace DK.POC.EFCoreCodeFirst
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("** EntityFramwork CodeFirst Experimental Project **");
                var conString = ConfigurationManager.AppSettings["sqldbConnection"];
                SqlConnection sqlConnection = new SqlConnection(conString);

                DAL.Services.IProductSrv dbProducts = new DAL.Services.ProductSrv();
                Console.WriteLine(dbProducts.GetName());


                var prods = new List<Products>();

                var prod1 = new DAL.Models.Products()
                {
                    ProductName = "HDD",
                    Description = "Some description",
                };
                prods.Add(prod1);
                var prod2 = new DAL.Models.Products()
                {
                    ProductName = "Mouse",
                    Description = "Hardware",
                };
                prods.Add(prod2);

                var cat = new DAL.Models.Categories()
                { Name = "Computer Items", Products = prods };

                //Loading Data to DB using Repository Pattern
                DAL.Services.ICategorySrv dbCategories = new DAL.Services.CategorySrv(sqlConnection);
                await dbCategories.NewCategotyAsync(cat);



                //Direct Loading Data to DB
                //using (var context = new DAL.DataAccess(sqlConnection))
                //{
                //    context.Categories.Add(cat);
                //    context.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
