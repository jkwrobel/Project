using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class XmlTypeManager : ITypeManager
    {
        private string _pathToFile = @"E:\Test.Xml";
        private List<ATypeRepresentation> typeRepresentations;

        private DllSerializer dllSerializer;
        public void InitTypeManager()
        {
            dllSerializer = DllSerializer.SerializerInstance;
        }

        public List<ATypeRepresentation> GetRootTypes()
        {
            if (typeRepresentations == null)
            {
                typeRepresentations = dllSerializer.DeserializeXmlToObject(_pathToFile).LocalRememberedTypesDictionary.Values.ToList();
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
