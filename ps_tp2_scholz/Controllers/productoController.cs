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

        [HttpPost] //2.
        public async Task<IActionResult> FilterProduct(FilterProductRequest filter)
        {
            var result = await _services.FilterProduct(filter);
            if (result == null)
            {
                return new JsonResult(result) { StatusCode = 204 }; //TODO: 400(Peticion Incorrecta)?
            }
            return new JsonResult(result) {StatusCode = 206}; //TODO: 206(Contenido Parcial)? 
        }

        [HttpGet("{id}")] //3.
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _services.GetProduct(id);
            if (result == null)
            {
                return new JsonResult(result) {StatusCode = 204}; //TODO: 400(Peticion Incorrecta)?
            }
            return new JsonResult(result) {StatusCode = 200}; 
        }
    }
}