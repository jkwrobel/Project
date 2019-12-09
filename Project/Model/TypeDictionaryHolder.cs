using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class TypeDictionaryHolder
    {
        [DataMember]
        public Dictionary<Guid, ATypeRepresentation> LocalRememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();
    }
}
