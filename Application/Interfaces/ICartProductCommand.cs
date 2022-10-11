using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartProductCommand
    {
        public Task InsertCP(CarritoProducto cp);
        public Task AddAmount(CarritoProducto cp, int cdad);
        public Task ChangeAmount(CarritoProducto cartProduct, int cdad);
        public Task DeleteProduct(CarritoProducto cartProduct);
    }
}
