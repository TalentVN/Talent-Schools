using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Area :EntityBase
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
