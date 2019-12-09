using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class TypeDictionaryHolder
    {
        [DataMember]
        public Dictionary<Guid, ATypeRepresentation> LocalRememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();
    }
}
