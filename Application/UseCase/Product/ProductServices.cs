using Application.Interfaces;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase.Product
{
    public class ProductServices : IProductServices
    {
        private readonly IProductCommand _command;
        private readonly IProductQuery _query;

        public ProductServices(IProductCommand command, IProductQuery query)
        {
            _command = command;
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
        
        public async Task<List<Producto>> GetProducts()
        {
            var list = await Task.Run(() => _query.GetListProduct());
            return list;
        }
    }
}
