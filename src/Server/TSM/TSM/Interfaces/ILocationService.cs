using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Entities;

namespace TSM.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<City>> GetCities();
    }
}
