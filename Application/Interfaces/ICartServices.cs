using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICartServices
    {
        //Endpoint 4
        Task<Carrito> CreateCart(CreateCartRequest request);
    }
}
