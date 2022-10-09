using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderCommand
    {
        //op.1
        Task InsertOrder(Orden order);
    }
}
