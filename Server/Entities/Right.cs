using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class Right
    {
        [Key, Column(Order = 0)]
        public string UserEmail { get; set; }

        [Key, Column(Order = 1)]
        public int PackageId { get; set; }

        [Required]
        public RightType Type { get; set; }

        public DateTime? Expires { get; set; }

        public virtual User User { get; set; }

        public virtual Package Package { get; set; }
    }
}
