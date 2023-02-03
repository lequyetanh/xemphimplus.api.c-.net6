using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace POS.API.CLONE.Entities
{
    [Table("user")]
    public class User_Entity
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        //public List<long> like { get; set; }
        //public List<long> love { get; set; }
        //public List<long> watchLater { get; set; }
        //public List<long> favorite { get; set; }
        //public string avatar { get; set; }
    }
}
