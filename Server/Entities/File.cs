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
        public FileType Type { get; set; }        

        public string Origin { get; set; }

        public DateTime? Date { get; set; }        

        [Required]
        public virtual byte[] Data { get; set; }

        //public virtual ICollection<Package> Packages { get; set; }

        

        public static explicit operator File(DataContracts.FileInfo info)
        {
            if (info == null)
                return null;

            var file = new File
            {
                Id = info.Id,
                Name = info.Name,
                Description = info.Description,
                OwnerEmail = info.OwnerEmail,
                Owner = (User) DatabaseController.GetUserByEmail(info.OwnerEmail),
                Type = info.Type,
                Origin = info.Origin,
                Date = info.Date,
                Data = null,
                Tags = new List<Tag>()
            };

            foreach (string text in info.Tags)
            {
                file.Tags.Add(new Tag { Text = text, Item = null });
            }

            return file;
        }

        public static explicit operator DataContracts.FileInfo(File file)
        {
            if (file == null)
                return null;

            var info = new DataContracts.FileInfo
            {
                Id = file.Id,
                Name = file.Name,
                Description = file.Description,
                OwnerEmail = file.OwnerEmail,
                Type = file.Type,
                Origin = file.Origin,
                Date = file.Date,
                Tags = new List<string>()
            };

            foreach (var tag in file.Tags)
            {
                info.Tags.Add(tag.Text);
            }

            return info;
        }
    }
}
