using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Package : Item
    {
        public virtual List<Membership> Memberships { get; set; }

        public static explicit operator Package(DataContracts.Package package)
        {
            if (package == null)
                return null;

            var pack = new Package
            {
                Id = package.Id,
                Name = package.Name,
                Description = package.Description,
                OwnerEmail = package.OwnerEmail,
                Owner = (User)DatabaseController.GetUserByEmail(package.OwnerEmail),
                Memberships = new List<Membership>()
            };            

            foreach (var fId in package.FileIds)
            {
                pack.Memberships.Add(new Membership {PackageId = pack.Id, FileId = fId});
            }

            return pack;
        }

        public static explicit operator DataContracts.Package(Package package)
        {
            if (package == null)
                return null;

            var pack = new DataContracts.Package
            {
                Id = package.Id,
                Name = package.Name,
                OwnerEmail = package.OwnerEmail,
                Description = package.Description,
                FileIds = new List<int>()
            };

            foreach (var membership in package.Memberships)
            {
                pack.FileIds.Add(membership.FileId);
            }

            return pack;
        }
    }
}
