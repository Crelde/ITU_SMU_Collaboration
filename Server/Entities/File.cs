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

        public List<int> PackageIds { get; set; }

        public virtual List<Package> Packages { get; set; }        

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
                Data = null
            };            

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
                Date = file.Date
            };            

            return info;
        }
    }
}
