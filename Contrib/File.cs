using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contrib
{
    
    public class File
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sup Everyone! FEEEEEEEEEST");
            Console.ReadKey();
        }
        private string Id;
        public string id { get { return Id; } set { Id = value; } } 

        private string Name;
        public string name { get { return Name; } set { Name = value; } }

        private string Origin;
        public string origin { get { return Origin; } set { Origin = value; } }

        private string Description;
        public string description { get { return Description; } set { Description = value; } }
        //derp
        private DateTime Date;
        public DateTime date { get { return Date; } set { Date = value; } }

        private FileType Type;
        public FileType type { get { return Type; } set { Type = value; } }

        private List<string> Tags;
        public List<string> tags { get { return Tags; } set { Tags = value; } }

        public enum FileType { doc, vid, sound } // others??

        public void AddTag(string tagName)
        {
            bool exists = false;
            for (int i = 0; i == tags.Count; i++)
            {
                if (tags.ElementAt(i).CompareTo(tagName) == 1)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                tags.Add(tagName);

            }
        }

        public void RemoveTag(string tagName)
        {
            bool exists = false;
            for (int i = 0; i == tags.Count; i++)
            {
                if (tags.ElementAt(i).CompareTo(tagName) == 1)
                {
                    exists = true;
                    tags.ElementAt(i).Remove(i);
                }
            }
            if (!exists)
            {
                Console.WriteLine("Tag does not exist!");

            }
        }
    }
}
