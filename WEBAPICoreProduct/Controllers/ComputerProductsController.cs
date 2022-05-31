using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPICoreProduct.Controllers
{
    [Route("api/[controller]")] // attribute based routing and decoration purpose
    [ApiController] // with the help of this compiler will know that it is api controller
    public class ComputerProductsController : ControllerBase
    {

        public static List<Product> ProductsList = new List<Product>()
        {
        new Product(){ ProductCode=101,ProductName="Speakers",ProductPrice=30000.00m},
        new Product(){ ProductCode=102,ProductName="Desktops",ProductPrice=30000.00m},
        new Product(){ ProductCode=103,ProductName="Laptops",ProductPrice=25000.00m},
        new Product(){ ProductCode=104,ProductName="Gaming PC's",ProductPrice=60000.00m},
        new Product(){ ProductCode=105,ProductName="Servers",ProductPrice=100000.00m},
        new Product(){ ProductCode=106,ProductName="Tablet",ProductPrice=5000.00m},
        new Product(){ ProductCode=107,ProductName="PC's Monitors",ProductPrice=5000.00m},
        new Product(){ ProductCode=108,ProductName="Memory",ProductPrice=2500.00m},
        new Product(){ ProductCode=109,ProductName="Printers",ProductPrice=4000.00m},
        new Product(){ ProductCode=110,ProductName="Projectors",ProductPrice=30000.00m}
        };

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductsList.ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        //public Product Get(int id)
        //{
        //    return ProductsList.FirstOrDefault(p=>p.ProductCode==id);
        //}
        public IActionResult Get(int id)
        {
            Product prod = ProductsList.FirstOrDefault(p => p.ProductCode == id);

            if (prod == null)
            {
                return NotFound();
            }

            return Ok(prod);
        }


        //*******************************************************

        // POST api/<ProductsController>
        [HttpPost]
        //public void Post([FromBody] Product product)
        //{
        //    ProductsList.Add(product);
        //}
        public IActionResult Post([FromBody] Product product)
        {
            Product prod = new Product();
            if (product != null)
            {
                prod = ProductsList.FirstOrDefault();
                if (prod != null)
                {
                    int id = ProductsList.Max(p => p.ProductCode);
                    product.ProductCode = id + 1;
                }

                else
                {
                    product.ProductCode = 101;
                }


                ProductsList.Add(product);
                return StatusCode(StatusCodes.Status201Created,product);
               // return Ok();
            }
            else
            {
                //return BadRequest();
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }
        //*********************************************************
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        public IActionResult Put(int id, [FromBody] Product product)
        {
            Product prod = ProductsList.FirstOrDefault(p => p.ProductCode == id);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.ProductPrice = product.ProductPrice;
                //return Ok();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            else
            {
                return BadRequest();

            }
        }

        //*****************************************************
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public IActionResult Delete(int id)
        {
            Product prod = ProductsList.FirstOrDefault(p => p.ProductCode == id);
            if (prod != null)
            {
                ProductsList.Remove(prod);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
