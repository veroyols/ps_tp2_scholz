using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductQuery
    {
        public Task<List<Producto>> GetListProduct();
        public Task<Producto> GetProduct(int productId);
    }
}
