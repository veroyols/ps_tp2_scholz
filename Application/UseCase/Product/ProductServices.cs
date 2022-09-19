using Application.Interfaces;
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

        //op.4
        public Task<Domain.Entities.Producto> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
        
        public Task<Domain.Entities.Producto> CreateProduct()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Producto> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Domain.Entities.Producto>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Producto> UpdateProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
