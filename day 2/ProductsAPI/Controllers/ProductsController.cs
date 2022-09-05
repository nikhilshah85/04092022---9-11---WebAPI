using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        Products pObj = new Products(); //instead we use Dependency Injection


        [HttpGet]
        [Route("plist")]
        public IActionResult GetAllProducts()
        {
            return Ok(pObj.GetAllProducts());
        }

        [HttpGet]
        [Route("plist/{pId}")]
        public IActionResult GetProductById(int pId)
        {
            try
            {
                return Ok(pObj.GetProductById(pId));
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }

        //[HttpGet]
        //[Route("plist/{isavailable}")]
        //public IActionResult GetProductByAvailability(bool isavailable)
        //{
        //    return Ok(pObj.ProductsInStock(isavailable));
        //}

        //[HttpGet]
        //[Route("plist/{categoty}")]
        //public IActionResult GetProductByCategory(string categoty)
        //{
        //    return Ok(pObj.ProductsByCategory(categoty));
        //}

        [HttpPost]
        [Route("plist/add")]
        public IActionResult AddProduct(Products newProduct)
        {
            return Created("", pObj.AddProduct(newProduct));
        }

        [HttpDelete]
        [Route("plist/delete/{pId}")]
        public IActionResult DeleteProduct(int pId)
        {
            return Accepted(pObj.DeleteProduct(pId));
        }

        [HttpPut]
        [Route("plist/edit/")]
        public IActionResult UpdateProduct(Products changes)
        {
            return Accepted(pObj.EditProduct(changes));
        }
    }
}



