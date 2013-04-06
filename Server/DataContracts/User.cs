using System.Runtime.Serialization;


namespace Server.DataContracts
{
    [DataContract]
    public class User : Proper
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public UserType Type { get; set; }

        public override bool IsProper()
        {
            return
                this.Email != null &&
                this.Password != null &&
                this.Type != null;
        }
    }
}
