using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace POS.API.CLONE.Entities
{
    [Table("movie")]
    public class Movie_Entity
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public long rate { get; set; }
        public string name_image { get; set; }
        //public List<string> vice_name_image { get; set; }
        public string real_name { get; set; }
        //public List<string> content { get; set; }
        public string status { get; set; }
        public string director { get; set; }
        //public List<string> actor { get; set; }
        //public List<string> genre { get; set; }
        //public List<string> country { get; set; }
        public long run_time { get; set; }
        public long views { get; set; }
        public long release_year { get; set; }
        //public List<string> tags { get; set; }
        public long rate_vote { get; set; }
        public string hrefLink { get; set; }
        public string trailer { get; set; }
        //public List<Movie_Informartion> movie { get; set; }
    }
}
