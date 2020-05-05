using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace DK.POC.EFCoreCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("** EntityFramwork CodeFirst Experimental Project **");
                var conString = ConfigurationManager.AppSettings["sqldbConnection"];
                SqlConnection sqlConnection = new SqlConnection(conString);

                //Loading Data to DB
                using (var context = new DAL.DataAccess(sqlConnection))
                {

                    var prods = new DAL.Models.Products()
                    {
                        ProductName = "HDD",
                        Description = "Some description"

                    };

                    context.Products.Add(prods);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
