using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductByID(int id);
        Product AddProduct(Product staff);
    }
}
