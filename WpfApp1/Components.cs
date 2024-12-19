using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt
{
    public class Components
    {
        public string Name { set; get; }
        public string MesureUnit { set; get; }
        public Components(string name, string mesureUnit)
        {
            Name = name;
            MesureUnit = mesureUnit;
        }
    }
}
