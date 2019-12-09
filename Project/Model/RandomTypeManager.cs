using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RandomTypeManager : ITypeManager
    {
        public void InitTypeManager()
        {
        }

        public List<ATypeRepresentation> GetRootTypes()
        {
            return PlaceholderForTypeManagement.PlaceholderGetTypesForType();
        }

        public List<ATypeRepresentation> GetChildrenForType(ATypeRepresentation typePlaceholder)
        {
            return PlaceholderForTypeManagement.PlaceholderGetTypesForType();
        }
    }
}
