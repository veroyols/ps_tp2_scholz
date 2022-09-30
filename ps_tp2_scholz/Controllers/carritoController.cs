using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carritoController : ControllerBase
    {
        private readonly ICartServices _services;

        public carritoController(ICartServices services)
        {
            _services = services;
        }
        //endpoint4
        [HttpPost]
        public async Task<IActionResult> AddProductCart(CreateCartRequest request)
        {
            var result = await _services.AddProductCart(request);
            return new JsonResult(result) { StatusCode = 201 }; 
        }
    }
}
