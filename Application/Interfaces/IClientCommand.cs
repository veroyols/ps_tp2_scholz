﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientCommand
    {
        //op.1
        Task InsertClient(Cliente client);
    }
}
