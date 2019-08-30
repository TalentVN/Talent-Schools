using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Models
{
    public class MajorModel
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
}
