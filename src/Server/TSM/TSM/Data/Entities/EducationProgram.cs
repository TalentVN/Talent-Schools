using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class EducationProgram : EntityBase
    {
        public EducationProgram()
        {

        }

        public EducationProgram(string name, string description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public virtual ICollection<ProgramScore> ProgramScores { get; set; }

        public virtual ICollection<SchoolEducationProgram> SchoolEducationPrograms { get; set; }
    }
}
