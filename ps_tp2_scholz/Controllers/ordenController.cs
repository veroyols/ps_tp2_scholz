using Application.Interfaces;
using Application.Models;
using Application.UseCase.CartProduct;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordenController : ControllerBase
    {
        private readonly IOrderServices _services;
        private readonly ICartServices _cartservices;
        private readonly ICartProductServices _cartproductservices;
        private readonly IProductServices _productservices;

        public ordenController(IOrderServices services, ICartServices cartservices, ICartProductServices cartproductservices, IProductServices productservices)
        {
            _services = services;
            _cartservices = cartservices;
            _cartproductservices = cartproductservices;
            _productservices = productservices;
        }

        //7. 
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateOrder(int id)
        {
            Carrito cart = await _cartservices.GetCartByClientId(id);
            await _cartservices.StatusFalse(cart.CarritoId);
            var list = _cartproductservices.GetCartProduct(cart.CarritoId);
            decimal total = 0;
            foreach (var item in list.Result)
            {
                decimal precio = _productservices.GetPrecio(item.productoId).Result;
                total += item.cantidad * precio;
            }
            var orden = await _services.CreateOrder(cart.CarritoId, id, total);
            return new JsonResult(orden.Total) { StatusCode = 201 };
        }

        //8.
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetOrdersRequest orderRequest)// TODO: get orders
        {
            var result = await _services.GetOrders(orderRequest);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
