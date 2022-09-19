using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductServices
    {
        Task<Producto> CreateProduct();
        Task<Producto> UpdateProduct(int productId);
        Task<List<Producto>> GetProducts();
        Task<Producto> DeleteProduct(int productId);
        Task<Producto> GetProduct(int productId);
    }
}
