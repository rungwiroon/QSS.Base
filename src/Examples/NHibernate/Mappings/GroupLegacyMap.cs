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
    public class GroupLegacyMap : ClassMapping<GroupLegacyEntity>
    {
        public GroupLegacyMap()
        {
            Id(en => en.Id, map => map.Generator(Generators.Identity));
            Property(en => en.Name);
            Property(en => en.GroupNo, map =>
            {
                map.Unique(true);
                map.NotNullable(true);
            });

            Set(en => en.Items, map =>
            {
                map.Key(km =>
                {
                    km.Column("GroupNo");
                    km.PropertyRef(pr => pr.GroupNo);
                });
            }, r =>
            {
                r.OneToMany(o =>
                {

                });
            });
        }
    }
}
