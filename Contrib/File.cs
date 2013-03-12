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
            Console.WriteLine("sup Kewin");
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

        private DateTime Date;
        public DateTime date { get { return Date; } set { Date = value; } }

        private FileType Type;
        public FileType type { get { return Type; } set { Type = value; } }

        public enum FileType { doc, vid, sound } // others??
    }
}
