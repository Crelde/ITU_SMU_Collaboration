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
        public int ItemId { get; set; }

        [Required]
        public RightType Type { get; set; }

        public DateTime? Until { get; set; }

        public virtual Item Item { get; set; }

        public static explicit operator Right(DataContracts.Right right)
        {
            if (right == null)
                return null;

            return new Right
            {
                UserEmail = right.UserEmail,
                ItemId = right.ItemId,
                Type = right.Type,
                Until = right.Until,
                Item = DatabaseController.GetItemById(right.ItemId)
            };
        }

        public static explicit operator DataContracts.Right(Right right)
        {
            if (right == null)
                return null;

            return new DataContracts.Right
            {
                UserEmail = right.UserEmail,
                ItemId = right.ItemId,
                Type = right.Type,
                Until = right.Until
            };
        }
    }
}
