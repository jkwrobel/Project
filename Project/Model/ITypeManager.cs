using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ITypeManager
    {
        void InitTypeManager();
        List<ATypeRepresentation> GetRootTypes();
        List<ATypeRepresentation> GetChildrenForType(ATypeRepresentation typePlaceholder);
    }
}
