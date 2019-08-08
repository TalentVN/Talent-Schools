using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;

namespace TSM.Data.Entities
{
    public class Rating : EntityBase
    {
        private Rating()
        {

        }

        public Rating(Guid schoolId,Guid userId, RatingType ratingType, string comment, int value)
        {
            SchoolId = schoolId;
            Comment = comment;
            Value = value;
            UserId = userId;
            RatingType = ratingType;
        }

        [MaxLength(200)]
        [Required]
        public string Comment { get; set; }

        public RatingType RatingType { get; set; }

        [Range(1,5)]
        [Required]
        public int Value { get; set; }

        [Required]
        public Guid SchoolId { get; set; }

        public School School { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
