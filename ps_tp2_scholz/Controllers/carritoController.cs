using Application.Interfaces;
using Application.Models;
using Domain.Entities;
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

        //4.
        [HttpPost]
        public async Task<IActionResult> AddProductCart(CreateCartRequest request)
        {
            var cart = await _cartservices.ValidarCarrito(request);
            var result = await _cartproductservices.AddProductCart(request, cart);
            return new JsonResult(result) { StatusCode = 201 };
        }

        //5. 
        [HttpPut]
        public async Task<IActionResult> UpdateCart(CreateCartRequest request)
        {
            Carrito cart;
            try
            {
                cart = await _cartservices.GetCartByClientId(request.clientId);
                await _cartproductservices.UpdateCart(cart, request);
                return new JsonResult("Modificado") { StatusCode = 201 };
            }
            catch (Exception)
            {
                return new JsonResult("El id de cliente no existe") { StatusCode = 201 };
            }
        }

        //6.
        [HttpDelete("{clientId}/{productId}")]
        public async Task<IActionResult> DeleteProduct(int clientId, int productId)
        {
            var cart = _cartservices.GetCartByClientId(clientId);
            await _cartproductservices.DeleteProduct(cart.Result, productId); 
            return new JsonResult("Eliminado") { StatusCode = 200 };
        }
    }
}
