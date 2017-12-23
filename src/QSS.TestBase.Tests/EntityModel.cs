using Qss.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSS.TestBase.Tests
{
    public class EntityModel : IEntityKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
