using Model.DllTypes;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
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
                new DataContractSerializer(typeof(DllTypeManager), dcss);

        }


        public void SerializeObjectToXMl(DllTypeManager dllTypeManager, string pathToFile)
        {
            using (FileStream stream = File.Create(pathToFile))
            {
                dllTypeManager.LocalRememberedTypesDictionary = DllTypeManager.RememberedTypesDictionary;
                dataContractSerializer.WriteObject(stream, dllTypeManager);
            }
        }

        public DllTypeManager DeserializeXmlToObject(string pathToXml)
        {

            FileStream fs = new FileStream(pathToXml, FileMode.Open);
            XmlDictionaryReaderQuotas xdrq = new XmlDictionaryReaderQuotas();
            xdrq.MaxDepth = 1000000;
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, xdrq);

            return (DllTypeManager)dataContractSerializer.ReadObject(reader);


        }
    }
}
