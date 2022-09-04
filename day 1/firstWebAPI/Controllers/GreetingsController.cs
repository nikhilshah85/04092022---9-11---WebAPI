using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        //every method is called as Action here
        //every Action will have a return type as IActionResult
        //every action result has to return an HttpStatus Code - 404, 200, 201 etc... there are 5 categories of HttpStatus code
        //every method needs to be expressed as CRUD, HTTPGET, HTTPPUT, HTTPPOST, HTTPDELETE
        //every method should have a unique ROUTE attribute

        [HttpGet]
        [Route("greet")]   
        public IActionResult Greetings()
        {
            return Ok("Welcome to Web API");
        }

        [HttpGet]
        [Route("greet/{name}")]
        public IActionResult Greetings(string name)
        {
            return Ok("Hello and welcome to WebAPI  " + name);
        }


        [HttpGet]
        [Route("calculate/{num1}/{num2}")]
        public IActionResult Calculate(int num1, int num2)
        {
            if (num1 == 0 || num2 == 0)
            {
                return Ok("Sorry, we do not calculate negative numbers");
            }

            return Ok(num1 + num2);
        }
    }
}
