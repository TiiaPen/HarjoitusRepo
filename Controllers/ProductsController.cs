using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        // säilytetään tuotteita Arrayssa
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomaattikeitto", Category = "Elintarvikkeet", Price = 1 },
            new Product { Id = 2, Name = "Hyppynaru", Category = "Lelut", Price = 3.75M },
            new Product { Id = 3, Name = "Vasara", Category = "Työkalut", Price = 16.99M }
        };

        // The GetAllProducts method returns the entire list 
        // of products as an IEnumerable<Product> type.
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        // The GetProduct method looks up a single product by its ID.
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Each method on the controller corresponds to one or more URIs:
        // GetAllProducts -> /api/products
        // GetProduct -> /api/products/id

        // For the GetProduct method, the id in the URI is a placeholder. 
        // For example, to get the product with ID of 5, the URI is api/products/5
    }
}
