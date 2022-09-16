using Application.Interfaces;
using Application.UseCase.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ps_tp1_scholz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _services; //se inyecta un cliente para evitar que lo cree el metodo
        //CONSTRUCTOR
        public ClientController(IClientServices services) //
        {
            _services = services;
        }

        [HttpPost] //crear
        public IActionResult CreateClient()
        {
            //ACOPLADO
            //var services = new ClientServices();
            var result = _services.CreateClient();
            return new JsonResult(result);
        } 
         
    }
}
