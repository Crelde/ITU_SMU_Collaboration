using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class Tag
    {
        [Key, Column(Order = 0)]
        public string Text { get; set; }

        [Key, Column(Order = 1)]
        public int ItemId { get; set; }

        [Required]
        public virtual Item Item { get; set; }
    }
}
