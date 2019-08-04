using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;
using TSM.Models.ResponseModels;

namespace TSM.Models
{
    public class CreateRatingRequestModel
    {
        [MaxLength(200)]
        public string Comment { get; set; }

        public RatingType RatingType { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }

        public Guid UserId { get; set; }

        public Guid SchoolId { get; set; }
    }
}
