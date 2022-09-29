using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<Producto>> GetProducts()
        {
            var list = await Task.Run(() => _query.GetListProduct());// error await
            return list;
        }
        //3.
        public async Task<Producto> GetProduct(int productId)
        {
            var p = await Task.Run(() => _query.GetProduct(productId));
            return p;
        }
        public Task<Producto> CreateProduct()
        {
            throw new NotImplementedException();
        }
        public Task<Producto> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
        public Task<Producto> UpdateProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
