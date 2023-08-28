namespace T31_API_NET_Core.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nom_emp { get; set; }
        public bool IsComplete { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
