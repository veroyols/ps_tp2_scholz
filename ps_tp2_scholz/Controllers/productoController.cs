using Application.Interfaces;
using Application.UseCase.Product;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetProducts();
            return new JsonResult(result) { StatusCode = 200 };
        }
        [HttpGet("{id}")] //endpoint 3
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _services.GetProduct(id);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}