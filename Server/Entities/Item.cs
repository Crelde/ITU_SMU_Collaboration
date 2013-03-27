using System.ComponentModel.DataAnnotations.Schema;
namespace Server.Entities
{
    public abstract class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
