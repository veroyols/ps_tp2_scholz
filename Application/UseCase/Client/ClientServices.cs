using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Client
{
    public class ClientServices : IClientServices
    {
        public object CreateClient()
        {
            return new { name = "string" };
        }
    }
}
