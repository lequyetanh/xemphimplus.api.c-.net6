using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;

namespace POS.API.CLONE.Repositories
{
    public class CountryRepositories:CountryIRepositories
    {
        private readonly ApplicationContext _context;

        public CountryRepositories(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> getListCountry()
        {
            List<Country> listCountry = new List<Country>();
            listCountry = _context.Country.ToList();
            return listCountry;
        }

        public async Task<Country> getCountryDetail(long country_id)
        {
            Country country = _context.Country.FirstOrDefault(r => r.id == country_id);
            return country;
        }

        public async Task<Country> CountryCreate(Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();
            return country;
        }

        public async Task<Country> countryModify(Country country)
        {
            var countryUpdate = _context.Country.FirstOrDefault(r => r.id == country.id);

            countryUpdate.name = country.name;

            _context.Country.Update(countryUpdate);
            _context.SaveChanges();
            return countryUpdate;
        }

        public async Task<Country> countryDelete(long country_id)
        {
            var country = _context.Country.FirstOrDefault(r => r.id == country_id);
            _context.Country.Remove(country);
            _context.SaveChanges();
            return country;
        }
    }

}
