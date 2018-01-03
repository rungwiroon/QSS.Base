using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Entities
{
    public class GroupLegacyEntity
    {
        public virtual int Id { get; set; }

        public virtual int GroupNo { get; set; }

        public virtual string Name { get; set; }

        public virtual ISet<ItemLegacyEntity> Items { get; set; }
    }
}
