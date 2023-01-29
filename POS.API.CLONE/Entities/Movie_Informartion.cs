using System.ComponentModel.DataAnnotations;

namespace POS.API.CLONE.Entities
{
    public class Movie_Informartion
    {
        [Key]
        public int id { get; set; }
        public string video { get; set; }
        public string episode { get; set; }
        public string subtitle { get; set; }
    }
}
