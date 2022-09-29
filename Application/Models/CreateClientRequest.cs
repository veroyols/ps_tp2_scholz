using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateClientRequest //dto: objeto que espero en una creacion de cliente
    {
        public string dni { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}
