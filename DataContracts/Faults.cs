using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class IndexFault
    {
        [DataMember]
        public int RequestedIndex { get; set; }

        [DataMember]
        public int MaxIndex { get; set; }

        [DataMember]
        public string Reason { get; set; }
    }
}
