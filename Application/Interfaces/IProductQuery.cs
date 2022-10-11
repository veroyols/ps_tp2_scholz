using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductQuery
    {
        public Task<List<Producto>> GetListProduct();
        public Task<Producto> GetProduct(int productId);
        public Task<List<Producto>> GetListProduct(FilterProductRequest filter);

    }
}
