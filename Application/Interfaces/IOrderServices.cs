using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        //op2
        Task<Orden> CreateOrder();
        //op3
        Task<List<Orden>> GetOrders();

        Task<Orden> UpdateOrder(int productId);
        Task<Orden> DeleteOrder(int productId);
        Task<Orden> GetOrder(int productId);
    }
}