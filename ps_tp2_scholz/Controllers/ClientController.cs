using Application.Interfaces;
using Application.UseCase.Client;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ps_tp2_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _services; 
        public ClientController(IClientServices services) 
        {
            _services = services;
        }
        //endpoint1
        [HttpPost] 
        public async Task<IActionResult> CreateClient(CreateClientRequest request)
        {
            var result = await _services.CreateClient(request);
            return new JsonResult(result);
        }
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetClients();
            return new JsonResult(result) { StatusCode = 200 };
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await _services.GetClient(id);
            return new JsonResult(result) { StatusCode = 200 };
        }

    }
}
