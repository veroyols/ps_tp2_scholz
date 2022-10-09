using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.cqrs_Command
{
    public class CartProductCommand : ICartProductCommand
    {
        private readonly AppDbContext _context;

        public CartProductCommand(AppDbContext context)
        {
            _context = context;
        }

        //4. TODO
        public async Task AddProductCart(CarritoProducto cp)
        {
            _context.CarritoProductoDb.Add(cp);
            await _context.SaveChangesAsync();
        }

        //5. TODO
        public Task UpdateCart(CreateCartRequest cart)
        {
            throw new NotImplementedException();
        }

        //6. TODO
        public async Task DeleteProduct(int clientId, int productId)
        {
            var cart = _context.CarritoDb.FirstOrDefault(x => x.ClienteId == clientId && x.Estado);
            var cp = _context.CarritoProductoDb
                .FirstOrDefault(x =>
                    x.CarritoId == cart.CarritoId &&
                    x.ProductoId == productId);

            await Task.FromResult(_context.Remove<CarritoProducto>(cp));
        }
    }
}
