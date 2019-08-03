using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class MajorScore : EntityBase
    {
        public MajorScore()
        {

        }

        public MajorScore(int year, decimal value, Guid majorId)
        {
            this.Year = year;
            this.Value = value;
            this.MajorId = majorId;
        }

        public int Year { get; set; }

        public decimal Value { get; set; }

        public Guid MajorId { get; set; }

        public Major Major { get; set; }
    }
}
