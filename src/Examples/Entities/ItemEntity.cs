using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Entities
{
    public class ItemEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual GroupEntity Group { get; set; }
    }
}
