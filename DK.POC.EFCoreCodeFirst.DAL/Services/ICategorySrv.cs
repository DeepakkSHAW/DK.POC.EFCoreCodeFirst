using DK.POC.EFCoreCodeFirst.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DK.POC.EFCoreCodeFirst.DAL.Services
{
    public interface ICategorySrv
    {
        Task<Categories> GetCategory(int Id);
        Task<List<Categories>> GetCategories();
        Task NewCategotyAsync(Categories category);
        Task<int> NewCategotiesAsync(List<Categories> categories);

    }
}
