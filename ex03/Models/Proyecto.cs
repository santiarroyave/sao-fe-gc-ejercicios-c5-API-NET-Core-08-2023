namespace ex03.Models
{
    public class Proyecto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public int horas { get; set;}

        public virtual ICollection<Cientifico_Proyecto>? cientifico_proyecto { get; set;}
    }
}
