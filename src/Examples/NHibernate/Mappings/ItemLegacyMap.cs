using Examples.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Repositories.NHibernate
{
    public class ItemLegacyMap : ClassMapping<ItemLegacyEntity>
    {
        public ItemLegacyMap()
        {
            Id(en => en.Id, map => map.Generator(Generators.Identity));

            Property(en => en.Name);

            ManyToOne(en => en.Group, map =>
            {
                map.Column("GroupNo");
                map.PropertyRef("GroupNo");
            });
        }
    }
}
