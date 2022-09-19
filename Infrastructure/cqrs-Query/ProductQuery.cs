using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.cqrs_Query
{
    public class ProductQuery : IProductQuery
    {
        public List<Producto> GetListProduct()
        {
            throw new NotImplementedException();
        }

        public Producto GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
