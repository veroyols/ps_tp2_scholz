using Application.Interfaces;
using Application.UseCase.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp1_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services; //se inyecta un cliente para evitar que lo cree el metodo
        //CONSTRUCTOR
        public ProductController(IProductServices services) //
        {
            _services = services;
        }

        [HttpGet] 
        public async Task<IActionResult> GetProduct(int productId)
        {
            var result = await _services.GetProduct(productId);
            return new JsonResult(result);
        }
    }
}