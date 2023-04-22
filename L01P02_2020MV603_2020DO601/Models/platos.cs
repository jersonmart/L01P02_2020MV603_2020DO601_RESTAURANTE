using System.ComponentModel.DataAnnotations;

namespace L01P02_2020MV603_2020DO601.Models
{
    public class platos
    {
        [Key]

        public int platoId { get; set; }
        public string nombrePlato { get; set; }
        public decimal precio { get; set; }
    }
}
