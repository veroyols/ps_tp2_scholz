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
