using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _services;

        public CartController(ICartServices services)
        {
            _services = services;
        }

        //endpoint4
        [HttpPost]
        public async Task<IActionResult> CreateCart(CreateCartRequest request)
        {
            var result = await _services.CreateCart(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
    }
}
