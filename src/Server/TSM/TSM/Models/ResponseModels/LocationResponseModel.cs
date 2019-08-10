using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Models.ResponseModels
{
    public class LocationResponseModel
    {
        public string Address { get; set; }

        public string Street { get; set; } // Đường, thôn, xóm

        public string Ward { get; set; } // Phường, xã

        public string District { get; set; } // Quận, huyện

        public Guid CityId { get; set; }

        public Guid CountryId { get; set; }
    }
}
