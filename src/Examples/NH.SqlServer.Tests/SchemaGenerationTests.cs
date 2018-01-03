using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nh = NHibernate;

namespace Examples.NHibernate.SqlServer.Tests
{
    [TestClass]
    public class SchemaGenerationTests
    {
        [TestMethod]
        public void GenerateSchema()
        {
            var cfg = NHibernateHelper.CreateConfiguration();

            var schema = new Nh.Tool.hbm2ddl.SchemaExport(cfg);
            schema.SetOutputFile("schema.sql");
            schema.Create(true, true);
        }
    }
}
