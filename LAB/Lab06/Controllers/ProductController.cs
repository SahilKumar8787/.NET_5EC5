using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    Category = "Electronics",
                    Price = 55000,
                    Description = "High performance laptop suitable for study, programming and office work.",
                    Stock = "In Stock",
                    Rating = 4.5
                },

                new Product
                {
                    ProductId = 2,
                    ProductName = "Smartphone",
                    Category = "Electronics",
                    Price = 25000,
                    Description = "Modern smartphone with powerful performance and a clear display.",
                    Stock = "In Stock",
                    Rating = 4.3
                },

                new Product
                {
                    ProductId = 3,
                    ProductName = "Wireless Headphones",
                    Category = "Accessories",
                    Price = 2500,
                    Description = "Comfortable wireless headphones with clear sound quality.",
                    Stock = "In Stock",
                    Rating = 4.2
                },

                new Product
                {
                    ProductId = 4,
                    ProductName = "College Backpack",
                    Category = "Accessories",
                    Price = 1500,
                    Description = "Durable backpack suitable for college, books and laptop.",
                    Stock = "In Stock",
                    Rating = 4.4
                },

                new Product
                {
                    ProductId = 5,
                    ProductName = "Smart Watch",
                    Category = "Wearables",
                    Price = 3500,
                    Description = "Smart watch with fitness tracking and notification features.",
                    Stock = "Limited Stock",
                    Rating = 4.1
                },

                new Product
                {
                    ProductId = 6,
                    ProductName = "Bluetooth Speaker",
                    Category = "Audio",
                    Price = 2200,
                    Description = "Portable Bluetooth speaker with powerful and clear audio.",
                    Stock = "In Stock",
                    Rating = 4.0
                }
            };
        }


        // Product Catalog
        public ActionResult Index()
        {
            List<Product> products = GetProducts();

            return View(products);
        }


        // Product Details
        public ActionResult Details(int id)
        {
            Product product = GetProducts()
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}