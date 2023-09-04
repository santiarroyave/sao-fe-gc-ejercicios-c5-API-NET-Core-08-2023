namespace ex03.Models
{
    public class Cientifico
    {
        public string dni { get; set; }
        public string nomApels { get; set; }

        public virtual ICollection<Cientifico_Proyecto>? cientifico_proyecto { get; set;}
    }
}
