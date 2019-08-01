using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;

namespace TSM.Data.Entities
{
    public class School : EntityBase
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Website { get; set; }

        public string CoverUrl { get; set; }

        public int StudentCount { get; set; }

        public long TuiTion { get; set; }

        public string Description { get; set; }

        public Location Location { get; set; }

        public SchoolType SchoolType { get; set; }

        public virtual ICollection<SchoolEducationProgram> SchoolEducationPrograms { get; set; }

        public virtual ICollection<SchoolMajor> SchoolMajors { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
