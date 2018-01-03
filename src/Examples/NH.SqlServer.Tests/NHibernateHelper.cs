using Nh = NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.Repositories.NHibernate;

namespace Examples.NHibernate.SqlServer.Tests
{
    public class NHibernateHelper
    {
        private static Nh.ISessionFactory _sessionFactory;

        private static object _locker = new object();

        public static Nh.ISessionFactory SessionFactory
        {
            get
            {
                lock (_locker)
                {
                    if (_sessionFactory == null)
                    {
                        _sessionFactory = CreateSessionFactory();
                    }

                    return _sessionFactory;
                }
            }
        }

        public static Nh.Cfg.Configuration CreateConfiguration()
        {
            var configuration = new Nh.Cfg.Configuration();

            configuration
            .DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionProvider<DriverConnectionProvider>();
                c.ConnectionStringName = "ConnectionString";
                c.Driver<Sql2008ClientDriver>();
                c.LogSqlInConsole = true;
            });

            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(GroupMap).Assembly.GetExportedTypes());

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddMapping(mapping);

            return configuration;
        }

        private static Nh.ISessionFactory CreateSessionFactory()
        {
            var configuration = CreateConfiguration();

            return configuration.BuildSessionFactory();
        }
    }
}
