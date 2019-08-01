using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Rating : EntityBase
    {
        [MaxLength(200)]
        public string Comment { get; set; }

        public int RatingType { get; set; }

        [Range(1,5)]
        public int Value { get; set; }

        public Guid SchoolId { get; set; }

        public School School { get; set; }
    }
}
