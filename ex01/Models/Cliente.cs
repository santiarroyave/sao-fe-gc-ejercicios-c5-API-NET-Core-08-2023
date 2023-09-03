using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ex01.Models
{
    public class Cliente
    {
        public int clienteId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int dni { get; set; }
        public DateTime date { get; set; }
    }
}
