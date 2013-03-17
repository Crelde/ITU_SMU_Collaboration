using System;
using System.Collections.Generic;
namespace Contrib
{
    
    public class File
    {
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

        private HashSet<string> Tags;
        public HashSet<string> tags { get { return Tags; } set { Tags = value; } }

        public enum FileType { document, video, audio, image }

        public void AddTag(string tagName)
        {
            tags.Add(tagName);
        }

        public void RemoveTag(string tagName)
        {
            tags.Remove(tagName);
        }
    }
}
