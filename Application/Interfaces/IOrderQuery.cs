using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderQuery
    {
        List<Orden> GetListOrder();
        Orden GetOrder(int orderId);
    }
}
