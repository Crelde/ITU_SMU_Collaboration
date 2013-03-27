﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Server.DataContracts
{
    [DataContract]
    public abstract class Item
    {
        public Item()
        {
            // NOTE - Will be generated by EF.
            Id = -1;
            Description = "No description.";
            Tags = new List<string>();
            // NOTE - Should be filled out afterwards.
            OwnerEmail = null;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<string> Tags { get; set; }

        [DataMember]
        public string OwnerEmail { get; set; }
    }
}