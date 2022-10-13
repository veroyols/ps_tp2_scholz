using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.cqrs_Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly AppDbContext _context;

        public ProductQuery(AppDbContext context)
        {
            _context = context;
        }

        //2.
        public async Task<List<Producto>> GetListProduct(FilterProductRequest filter)
        {
            if (filter.orderBy) //TODO ASC DESC
            {
                var q1 = await Task.Run(() =>
                    from p in _context.Set<Producto>()
                    where p.Nombre == filter.productName
                    orderby p.Precio ascending
                    select p);
                return q1.ToList();
            }
            var query = await Task.Run(() =>
                from p in _context.Set<Producto>()
                where p.Nombre == filter.productName
                orderby p.Precio descending
                select p);
            return query.ToList();
        }

        //3.
        public async Task<Producto> GetProduct(int productId)
        {
            var p = await _context.ProductoDb.FindAsync(productId);
            return p;
        }

        public async Task<List<Producto>> GetListProduct()
        {
            var list = await Task.Run(() => _context.ProductoDb.ToList<Producto>());
            return list;
        }

        public async Task<decimal> GetPrecio(int productoId)
        {
            var p = await _context.ProductoDb.FirstOrDefaultAsync(x => x.ProductoId == productoId);
            return p.Precio;
        }
    }
}
