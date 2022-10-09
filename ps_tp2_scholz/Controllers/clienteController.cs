using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clienteController : ControllerBase
    {
        private readonly IClientServices _services; 
        public clienteController(IClientServices services) 
        {
            _services = services;
        }
        
        //1.
        [HttpPost] 
        public async Task<IActionResult> CreateClient(CreateClientRequest request)
        {
            var result = await _services.CreateClient(request);
            return new JsonResult(result) {StatusCode = 201};
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetClients();
            return new JsonResult(result) {StatusCode = 200};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _services.GetClient(id);
            if (result == null)
            {
                return new JsonResult(result) { StatusCode = 400 }; //TODO: msj?
            }
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
