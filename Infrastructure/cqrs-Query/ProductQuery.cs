using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.cqrs_Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly AppDbContext _context;

        public ProductQuery(AppDbContext context)
        {
            _context = context;
        }
        //2
        public async Task<List<Producto>> GetListProduct()
        {
            var list = await Task.Run(() => _context.ProductoDb.ToList<Producto>());// error await
            return list;
        }
        //.3
        public async Task<Producto> GetProduct(int productId)
        {
            var p = await _context.ProductoDb.FindAsync(productId);
            return p;
        }
    }
}
