using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DI_Demo.Model;
namespace DI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Products pObj = new Products(); //this is a crime

        Products _pObj;

        public ProductsController(Products _pObjREF)
        {
            _pObj = _pObjREF;
        }

        [HttpGet]
        [Route("plist")]
        public IActionResult GetAllProducts()
        {
            return Ok(_pObj.GetALlProduct());
        }
        [HttpGet]
        [Route("plist/{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_pObj.GetProductById(id));
        }
    }
}
