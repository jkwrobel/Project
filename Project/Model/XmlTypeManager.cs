using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class XmlTypeManager : TypeDictionaryHolder, ITypeManager
    {
        private string _pathToFile = @"E:\Test.Xml";
        private List<ATypeRepresentation> typeRepresentations;

        private DllSerializer _dllSerializer;
        public void InitTypeManager()
        {
            _dllSerializer = DllSerializer.SerializerInstance;
        }

        public List<ATypeRepresentation> GetRootTypes()
        {
            if (typeRepresentations == null)
            {
                LocalRememberedTypesDictionary =
                    _dllSerializer.DeserializeXmlToObject(_pathToFile).LocalRememberedTypesDictionary;
                typeRepresentations = LocalRememberedTypesDictionary.Values.ToList();
            }

            return typeRepresentations;
        }

        public List<ATypeRepresentation> GetChildrenForType(ATypeRepresentation typePlaceholder)
        {
            return typePlaceholder.ReferencedTypes;
        }

        public void AssignPathToFile(string pathToFile)
        {
            typeRepresentations = null;
            _pathToFile = pathToFile;
        }
    }
}
