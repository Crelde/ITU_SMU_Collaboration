using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Server.DataContracts
{
    [DataContract]
    public class Package : Item
    {
        public Package()
            : base()
        {
            FileInfos = new List<FileInfo>();
        }

        [DataMember]
        public List<FileInfo> FileInfos { get; set; }
    }
}
