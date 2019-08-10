using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Data.Entities;

namespace TSM.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<City>> GetCities();
        Task<IEnumerable<Country>> GetCountries();
    }
}