using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;
using TSM.Models.ResponseModels;

namespace TSM.Models
{
    public class RatingModel
    {
        public string Comment { get; set; }

        public RatingType RatingType { get; set; }

        public int Value { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserResponseModel User { get; set; }

        public Guid SchoolId { get; set; }
    }
}
