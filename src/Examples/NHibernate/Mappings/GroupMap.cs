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
    public class GroupMap : ClassMapping<GroupEntity>
    {
        public GroupMap()
        {
            Id(en => en.Id, map => map.Generator(Generators.Identity));
            Property(en => en.Name);

            Set(en => en.Items, map =>
            {
                map.Key(km =>
                {
                    km.Column("GroupId");
                });
            }, r=>
            {
                r.OneToMany(o => 
                {
                });
            });
        }
    }
}
