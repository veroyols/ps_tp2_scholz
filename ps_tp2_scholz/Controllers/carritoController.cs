using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carritoController : ControllerBase
    {
        private readonly ICartServices _cartservices;
        private readonly ICartProductServices _cartproductservices;

        public carritoController(ICartServices services, ICartProductServices cartproductservices)
        {
            _cartservices = services;
            _cartproductservices = cartproductservices;
        }

        //4. TODO Agregar producto al carrito
        [HttpPost]
        public async Task<IActionResult> AddProductCart(CreateCartRequest request)
        {
            var cart = await _cartservices.ValidarCarrito(request);
            var result = await _cartproductservices.AddProductCart(request, cart);
            return new JsonResult(result) { StatusCode = 201 }; 
        }

        //5. TODO Modificar el carrito
        [HttpPut]
        public async Task<IActionResult> UpdateCart(CreateCartRequest request)
        {
            await _cartproductservices.UpdateCart(request);
            return new JsonResult(new { }) { StatusCode = 201 };
        }

        //6. TODO Eliminar producto del carrito
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int clientId, int productId)
        {
            var result = await _cartproductservices.DeleteProduct(clientId, productId); 
            return new JsonResult(result) { StatusCode = 204 };
        }
    }
}
