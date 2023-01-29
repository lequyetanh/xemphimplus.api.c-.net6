using POS.API.CLONE.Entities;
using POS.API.CLONE.Model;

namespace POS.API.CLONE.IRepositories
{
    public interface CountryIRepositories
    {
        Task<List<Country>> getListCountry();
        Task<Country> getCountryDetail(long country_id);
        Task<Country> CountryCreate(Country country);
        Task<Country> countryModify(Country country);
        Task<Country> countryDelete(long country_id);
    }
}
