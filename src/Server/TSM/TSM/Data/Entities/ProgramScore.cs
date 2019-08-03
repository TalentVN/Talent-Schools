using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class ProgramScore : EntityBase
    {
        public ProgramScore()
        {

        }

        public ProgramScore(int year, decimal value, Guid programId)
        {
            this.Year = year;
            this.Value = value;
            this.EducationProgramId = programId;
        }

        public int Year { get; set; }

        public decimal Value { get; set; }

        public Guid EducationProgramId { get; set; }

        public EducationProgram EducationProgram { get; set; }
    }
}
