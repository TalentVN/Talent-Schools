using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Major : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public virtual ICollection<SchoolMajor> SchoolMajors { get; set; }
    }
}
