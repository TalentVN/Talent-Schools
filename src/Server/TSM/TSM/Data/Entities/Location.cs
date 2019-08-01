using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Location : EntityBase
    {
        public string Street { get; set; } // Đường, thôn, xóm

        public string Ward { get; set; } // Phường, xã

        public string District { get; set; } // Quận, huyện

        public City City { get; set; } // Tỉnh, thành phố

        public Area Area { get; set; } // Vùng, khu vực

        public Country Country { get; set; } // Quốc gia

        public Guid SchoolId { get; set; }

        public School School { get; set; }

        public string Address {
            get
            {
                return City.Name + "," + Country.Name;
            }
        }
    }
}
