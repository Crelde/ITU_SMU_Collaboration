using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class Membership
    {
        [Key, Column(Order = 0)]
        public int PackageId { get; set; }

        [Key, Column(Order = 1)]
        public int FileId { get; set; }               
    }
}
