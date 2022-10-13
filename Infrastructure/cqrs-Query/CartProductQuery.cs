using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.cqrs_Query
{
    public class CartProductQuery : ICartProductQuery
    {
        private readonly AppDbContext _context;

        public CartProductQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CarritoProducto> GetCartProduct(Guid cart, int productId)
        {
            var cp = await _context.CarritoProductoDb
                .FirstOrDefaultAsync(x =>
                x.CarritoId == cart &&
                x.ProductoId == productId);
            return cp;
        }

        public async Task<bool> Exists(CarritoProducto cartProd)
        {
            var cartProdBd = await _context.CarritoProductoDb
                .AnyAsync(x => x.CarritoId == cartProd.CarritoId && x.ProductoId == cartProd.ProductoId);
            return cartProdBd;
        }

        public async Task<List<CarritoProducto>> GetCartProduct(Guid carritoId)
        {
            var query = await Task.Run(() =>
                from cp in _context.CarritoProductoDb
                where cp.CarritoId == carritoId
                select cp);
            return query.ToList();
        }
    }
}
