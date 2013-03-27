using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class File : Item
    {
        [Required]
        public string OwnerEmail { get; set; }
       
        [Required]
        public FileType Type { get; set; }        

        public string Origin { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        [Required]
        public virtual byte[] Data { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
