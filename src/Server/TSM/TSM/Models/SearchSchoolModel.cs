using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;

namespace TSM.Models
{
    public class SearchSchoolModel
    {
        public SchoolType SelectedSchoolType { get; set; }

        public Specialty SelectedSpecialty { get; set; }

        public Guid SelectedProgram { get; set; }

        public Guid SelectedCity { get; set; }

        public long TuiTion { get; set; }

        public int MaxScore { get; set; }

        public int MinScore { get; set; }

        public RatingType RatingType { get; set; }
    }
}
