using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.DTOs;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepo _repository;
        public ProductController(IProductRepo repository)
        {
            _repository = repository;

        }
        [HttpGet("GetItems")]
        public ActionResult<IEnumerable<ProductOutDto>> GetItems()
        {
            IEnumerable<Product> product = _repository.GetAllProduct();
            IEnumerable<ProductOutDto> c = product.Select(e => new ProductOutDto
            {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price
            });
            return Ok(c);
        }
        [HttpGet("GetItems/{s}")]
        public ActionResult<IEnumerable<ProductOutDto>> GetItems(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return GetItems();
            }
            IEnumerable<Product> product = _repository.GetAllProduct();
            IEnumerable<Product> c = product.Where(e => e.Name.ToLower().Contains(s.ToLower()));
            return Ok(c);
            //return c;
        }
        [HttpGet("GetItemPhoto/{Id}")]
        public ActionResult GetProductImage(int Id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "ItemsImages");
            string fileName1 = Path.Combine(imgDir, Id + ".png");
            string fileName2 = Path.Combine(imgDir, Id + ".jpg");
            string respHeader = "image/png";
            if (System.IO.File.Exists(fileName1))
            {
                return PhysicalFile(fileName1, respHeader);
            }
            else if (System.IO.File.Exists(fileName2))
            {
                return PhysicalFile(fileName2, respHeader);
            }
            else
            {
                fileName1 = Path.Combine(imgDir, "default.png");
                return PhysicalFile(fileName1, respHeader);
            }
            

        }


    }
}
