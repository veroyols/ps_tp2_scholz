using Domain.Entities;


namespace Application.Interfaces
{
    public interface ICartProductQuery
    {
        public Task<bool> Exists(CarritoProducto cartProd);
        public Task<CarritoProducto> GetCartProduct(Guid cart, int productId);

    }
}
