using System;
using System.Runtime.Serialization;

namespace Server.DataContracts
{
    [DataContract]
    public class Right
    {
        [DataMember]
        public string UserEmail { get; set; }

        [DataMember]
        public RightsType Type { get; set; }

        [DataMember]
        public int ItemId { get; set; }
       
        [DataMember]
        public DateTime? Until { get; set; }
    }
}
