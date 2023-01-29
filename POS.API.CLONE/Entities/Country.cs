using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS.API.CLONE.Entities
{
    [Table("country")]
    public class Country
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
    }
}
