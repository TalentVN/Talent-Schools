using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Data.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = DateTime.UtcNow;
            this.IsActive = true;
        }

        public Guid Id { get; private set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
