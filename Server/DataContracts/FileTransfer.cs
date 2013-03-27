using System.Runtime.Serialization;

namespace Server.DataContracts
{
    [DataContract]
    public class FileTransfer
    {
        public FileTransfer() {
            Data = null;
            Info = null;
        }

        [DataMember]
        public byte[] Data { get; set; }
        [DataMember]
        public FileInfo Info { get; set; }
    }
}
