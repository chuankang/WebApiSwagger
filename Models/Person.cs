using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Description("用户model")]
    public class Person
    {
        [Description("姓名")]
        public string Name { get; set; }

        [Description("年纪")]
        public int Age { get; set; }
    }
}
