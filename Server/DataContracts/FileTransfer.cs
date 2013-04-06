using System.Runtime.Serialization;

namespace Server.DataContracts
{
    [DataContract]
    public class FileTransfer : Proper
    {
        public FileTransfer() {
            Data = null;
            Info = null;
        }

        [DataMember]
        public byte[] Data { get; set; }
        [DataMember]
        public FileInfo Info { get; set; }

        public override bool IsProper()
        {
            return
                Data != null &&
                Info != null &&
                Info.IsProper();
        }
    }
}
