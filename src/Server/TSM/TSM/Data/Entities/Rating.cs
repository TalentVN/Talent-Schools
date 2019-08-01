using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Rating : EntityBase
    {
        public Rating()
        {

        }

        public Rating(Guid schoolId, string comment, int value)
        {
            SchoolId = schoolId;
            Comment = comment;
            Value = value;
        }

        [MaxLength(200)]
        [Required]
        public string Comment { get; set; }

        public int RatingType { get; set; }

        [Range(1,5)]
        [Required]
        public int Value { get; set; }

        [Required]
        public Guid SchoolId { get; set; }

        public School School { get; set; }
    }
}
