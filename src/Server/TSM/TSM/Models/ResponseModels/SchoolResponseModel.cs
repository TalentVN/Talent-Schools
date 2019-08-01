using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;

namespace TSM.Models.ResponseModels
{
    public class SchoolResponseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }
        
        public string Website { get; set; }
        
        public string CoverUrl { get; set; }

        public int StudentCount { get; set; }

        public long TuiTion { get; set; }

        public string Description { get; set; }

        public SchoolType SchoolType { get; set; }

        public LocationResponseModel Location { get; set; }
    }
}
