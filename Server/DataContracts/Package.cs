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
            FileIds = new List<int>();
        }

        [DataMember]
        public List<int> FileIds { get; set; }
    }
}
