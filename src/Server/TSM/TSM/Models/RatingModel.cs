using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Models
{
    public class RatingModel
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        public int RatingType { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}
