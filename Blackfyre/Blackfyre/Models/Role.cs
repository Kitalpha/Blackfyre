using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackfyre.Models
{
    public class Role
    {
        public string Name { get; set; }
        public List<string> RoleType { get; set; }

        public Role(string name, List<string> roleType)
        {
            Name = name;
            RoleType = roleType;
        }
    }
}
