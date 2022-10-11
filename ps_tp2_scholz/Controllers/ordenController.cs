using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordenController : ControllerBase
    {
        private readonly IOrderServices _services;
        private readonly ICartProductServices _servicescp;

        public ordenController(IOrderServices services)
        {
            _services = services;
        }

        //7. TODO create order clientid
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateOrder(int id)
        {
            var result = await _services.CreateOrder(id);
            return new JsonResult(result) { StatusCode = 201 };
        }

        //8. TODO get orders
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetOrders();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
