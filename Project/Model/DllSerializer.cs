using Model.DllTypes;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Model
{
    public class DllSerializer
    {
        private static DataContractSerializer dataContractSerializer;

        private static DllSerializer _singleDllSerializer;

        public static DllSerializer SerializerInstance
        {
            get
            {
                if (_singleDllSerializer == null)
                {
                    _singleDllSerializer = new DllSerializer();
                }

                return _singleDllSerializer;
            }
        }

        private DllSerializer()
        {
            Type[] knownTypes =
            {
                typeof(ATypeRepresentation), typeof(DllTypeClass), typeof(DllTypeConstructor),
                typeof(DllTypeField), typeof(DllTypeMethod), typeof(DllTypeParameter),
                typeof(DllTypeProperty), typeof(DllTypeReturn)
            };

            DataContractSerializerSettings dcss = new DataContractSerializerSettings
            {
                PreserveObjectReferences = true,
                KnownTypes = knownTypes
            };
            dataContractSerializer =
                new DataContractSerializer(typeof(TypeDictionaryHolder), dcss);

        }


        public void SerializeObjectToXMl(TypeDictionaryHolder typeDictionaryHolder, string pathToFile)
        {
            TypeDictionaryHolder test = new TypeDictionaryHolder();
            test.LocalRememberedTypesDictionary = typeDictionaryHolder.LocalRememberedTypesDictionary;
            using (FileStream stream = File.Create(pathToFile))
            {
                dataContractSerializer.WriteObject(stream, test);
            }
        }

        public TypeDictionaryHolder DeserializeXmlToObject(string pathToXml)
        {

            FileStream fs = new FileStream(pathToXml, FileMode.Open);
            XmlDictionaryReaderQuotas xdrq = new XmlDictionaryReaderQuotas();
            xdrq.MaxDepth = 1000000;
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, xdrq);

            return (TypeDictionaryHolder)dataContractSerializer.ReadObject(reader);


        }
    }
}
