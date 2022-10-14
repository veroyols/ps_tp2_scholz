using Application.Interfaces;
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

        public async Task AddAmount(CarritoProducto cp, int cdad)
        {
            var up = _context.CarritoProductoDb.First(c => c.CarritoId == cp.CarritoId && c.ProductoId == cp.ProductoId);
            up.Cantidad += cdad;
            await _context.SaveChangesAsync();
        }

        //4.
        public async Task InsertCP(CarritoProducto cartProduct)
        {
            _context.CarritoProductoDb.Add(cartProduct);
            await _context.SaveChangesAsync();
        }

        //5. TODO
        public async Task ChangeAmount(CarritoProducto cartProduct, int cdad)
        {
            var up = _context.CarritoProductoDb.First(c => c.CarritoId == cartProduct.CarritoId && c.ProductoId == cartProduct.ProductoId);
            up.Cantidad = cdad;
            await _context.SaveChangesAsync();
        }

        //6. TODO
        public async Task DeleteProduct(CarritoProducto cartProduct)
        {           
            _context.CarritoProductoDb.Remove(cartProduct);
            await _context.SaveChangesAsync();
        }
    }
}
