using System.Data;

namespace ex02.Models
{
    public class Videos
    {
        //id int (11) NOT NULL auto_increment,
        //title varchar(250) DEFAULT NULL,
        //director varchar(250) DEFAULT NULL,
        //cli_id int (11) DEFAULT NULL,
        //PRIMARY KEY(id),
        //CONSTRAINT videos_fk FOREIGN KEY(cli_id) REFERENCES cliente(id)

        public int id { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        
        public int cli_id { get; set; }
        public virtual Cliente? cliente { get; set; }
    }
}
