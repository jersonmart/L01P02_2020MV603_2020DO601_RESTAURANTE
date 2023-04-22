using System.ComponentModel.DataAnnotations;

namespace L01P02_2020MV603_2020DO601.Models
{
    public class clientes
    {
        [Key]
        public int clienteId { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
    }
}
