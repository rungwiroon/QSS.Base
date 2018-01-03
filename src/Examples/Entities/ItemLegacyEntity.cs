using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Entities
{
    public class ItemLegacyEntity
    {
        public virtual int Id { get; set; }

        //public virtual int ItemCode { get; set; }

        public virtual string Name { get; set; }

        public virtual GroupLegacyEntity Group { get; set; }
    }
}
