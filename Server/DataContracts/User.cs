using System.Runtime.Serialization;


namespace Server.DataContracts
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public UserType Type { get; set; }
    }
}
