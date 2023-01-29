using System.ComponentModel.DataAnnotations;

namespace POS.API.CLONE.Model
{
    public class CountryModel
    {
        public long id { set; get; }
        public string name { set; get; } = string.Empty;
    }
}
