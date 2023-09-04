namespace ex03.Models
{
    public class Cientifico_Proyecto
    {
        public string cientifico_dni { get; set; }
        public string proyecto_id { get; set; }


        public virtual Proyecto? Proyecto { get; set; }
        public virtual Cientifico? Cientifico { get; set; }
    }
}
