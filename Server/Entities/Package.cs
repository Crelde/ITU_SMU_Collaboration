using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Package : Item
    {
        public virtual ICollection<File> Files { get; set; }
    }
}
