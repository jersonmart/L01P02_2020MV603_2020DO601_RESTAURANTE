using System.ComponentModel.DataAnnotations;

namespace L01P02_2020MV603_2020DO601.Models
{
    public class motorista
    {
        [Key]
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }
    }
}
