﻿namespace ex02.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string? apellido { get; set; }
        public string? direccion { get; set; }
        public int? dni { get; set; }
        public DateTime? date { get; set; }

        public virtual ICollection<Videos>? videos { get; set; }
    }
}
