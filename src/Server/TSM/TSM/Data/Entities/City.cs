using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class City : EntityBase
    {
        public string Name { get; set; }

        public string Code { get; set; }

        // public Guid AreaId { get; set; }

        // public Area Area { get; set; }
    }
}
