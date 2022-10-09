
namespace Application.Models
{
    public class CreateCartRequest
    {
        public int ClienteId { get; set; } //carrito
        public int ProductoId { get; set; } //cp
        public int Cantidad { get; set; } //cp
    }
}
