using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productoController : ControllerBase
    {
        private readonly IProductServices _services;
        public productoController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet] //2. 
        public async Task<IActionResult> FilterProduct([FromQuery] bool orderBy, [FromQuery] string productName = "all")
        {
            if (orderBy == null)
            {
                orderBy = false;
            }
            if (productName == "all")
            {
                var list = await _services.GetProducts(orderBy);
                return new JsonResult(list) { StatusCode = 206 };
            }
            FilterProductRequest filter = new FilterProductRequest
            {
                orderBy = orderBy,
                productName = productName
            };
            var result = await _services.FilterProduct(filter);
            if (result == null)
            {
                return new JsonResult(result) { StatusCode = 400 }; //400(Peticion Incorrecta)
            }
            return new JsonResult(result) { StatusCode = 206 }; //206(Contenido Parcial)
        }

        [HttpGet("{id}")] //3.
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _services.GetProduct(id);
            if (result == null)
            {
                return new JsonResult(result) { StatusCode = 400 }; 
            }
            return new JsonResult(result) {StatusCode = 200}; 
        }
    }
}