using System;
using System.Runtime.Serialization;

namespace Server.DataContracts
{
    [DataContract]
    public class FileInfo : Item
    {
        public FileInfo()
            : base()
        {
            // NOTE - Could be derived from attached File.
            Name = "New File";            
            // NOTE - Could be derived from attached File.
            Type = FileType.other;
            // NOTE - Could be derived from attached File.
            Date = DateTime.Today;
            Origin = "";
        }

        [DataMember]
        public FileType Type { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public string Origin { get; set; }
    }
}
