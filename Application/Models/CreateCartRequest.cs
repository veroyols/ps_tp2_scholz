
namespace Application.Models
{
    public class CreateCartRequest
    {
        public int clientId { get; set; } //carrito
        public int productId { get; set; } //cp
        public int amount { get; set; } //cp
    }
}
