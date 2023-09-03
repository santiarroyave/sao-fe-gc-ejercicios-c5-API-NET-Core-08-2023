using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ex01.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLength(250)]
        public string nombre { get; set; }

        [MaxLength(250)]
        public string apellido { get; set; }

        [MaxLength(250)]
        public string direccion { get; set; }

        [MaxLength(11)]
        public int dni { get; set; }

        public DateTime date { get; set; }
    }
}
