using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Location : EntityBase
    {
        public Location()
        {

        }

        public Location(Guid schoolId, Guid cityId, Guid countryId, string street, string ward, string district)
        {
            SchoolId = schoolId;
            CityId = cityId;
            CountryId = countryId;

            Street = street;
            Ward = ward;
            District = district;
        }

        public string Street { get; set; } // Đường, thôn, xóm

        public string Ward { get; set; } // Phường, xã

        public string District { get; set; } // Quận, huyện

        public Guid CityId { get; set; }

        public City City { get; set; } // Tỉnh, thành phố

        public Guid CountryId { get; set; }

        public Country Country { get; set; } // Quốc gia

        public Guid SchoolId { get; set; }

        public School School { get; set; }

        public string Address
        {
            get
            {
                return City.Name + "," + Country.Name;
            }
        }
    }
}
