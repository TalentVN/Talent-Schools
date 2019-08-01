using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class Major : EntityBase
    {
        public Major()
        {

        }

        public Major(string name, string description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public virtual ICollection<SchoolMajor> SchoolMajors { get; set; }
    }
}
