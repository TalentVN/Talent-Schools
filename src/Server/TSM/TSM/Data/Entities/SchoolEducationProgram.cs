using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class SchoolEducationProgram
    {
        public Guid SchoolId { get; set; }

        public School School { get; set; }

        public Guid EducationProgramId { get; set; }

        public EducationProgram EducationProgram { get; set; }
    }
}
