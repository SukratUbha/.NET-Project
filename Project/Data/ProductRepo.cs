using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Project.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly StaffDbContext _dbContext;
        public ProductRepo(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product staff)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            IEnumerable<Product> product = _dbContext.Product.ToList<Product>();
            return product;
        }

        public Product GetProductByID(int id)
        {
            Product product = _dbContext.Product.FirstOrDefault(e => e.ID == id);
            return product;
        }
    }
}
