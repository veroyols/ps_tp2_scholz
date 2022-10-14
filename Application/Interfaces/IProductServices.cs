using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductServices
    {
        public Task<List<Producto>> GetProducts(bool orderBy);
        public Task<Producto> GetProduct(int productId);
        public Task<List<Producto>> FilterProduct(FilterProductRequest filter);
        public Task<decimal> GetPrecio(int productoId);

    }
}
