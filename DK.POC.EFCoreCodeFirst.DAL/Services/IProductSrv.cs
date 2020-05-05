using DK.POC.EFCoreCodeFirst.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DK.POC.EFCoreCodeFirst.DAL.Services
{
    public interface IProductSrv
    {
        string GetName();
        Task NewProductAsync(Products product);
        Task<int> NewProductsAsync(List<Products> products);
    }
}
