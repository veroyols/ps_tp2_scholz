using Application.Interfaces;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase.Product
{
    public class ProductServices : IProductServices
    {
        private readonly IProductQuery _query;

        public ProductServices(IProductQuery query)
        {
            _query = query;
        }

        //2.
        public async Task<List<Producto>> FilterProduct(FilterProductRequest filtrar)
        {
            var list = await Task.Run(() => _query.GetListProduct(filtrar));
            return list;
        }

        //3.
        public async Task<Producto> GetProduct(int productId)
        {
            var p = await Task.Run(() => _query.GetProduct(productId));
            return p;
        }
        
        public async Task<List<Producto>> GetProducts(bool orderBy)
        {
            var list = await Task.Run(() => _query.GetListProduct(orderBy));
            return list;
        }
        public async Task<decimal> GetPrecio(int productoId)
        {
            return await _query.GetPrecio(productoId);
        }
    }
}
