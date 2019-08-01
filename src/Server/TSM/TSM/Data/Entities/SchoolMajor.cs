using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class SchoolMajor
    {
        public Guid SchoolId { get; set; }

        public School School { get; set; }

        public Guid MajorId { get; set; }

        public Major Major { get; set; }
    }
}
