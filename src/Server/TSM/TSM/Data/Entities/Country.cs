using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Country : EntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
