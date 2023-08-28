namespace T31_API_NET_Core.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool IsComplete { get; set;}
        public Empresa Empresa { get; set; }
    }
}
