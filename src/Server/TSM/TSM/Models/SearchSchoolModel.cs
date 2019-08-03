using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;

namespace TSM.Models
{
    public class SearchSchoolModel
    {
        public SchoolType SchoolType { get; set; }

        public Guid EducationProgramId { get; set; }

        public long TuiTion { get; set; }

        public Specialty Specialty { get; set; }
    }
}
