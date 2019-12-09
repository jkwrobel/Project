using System.Collections.Generic;

namespace Model
{
    public interface ITypeManager
    {
        void InitTypeManager();
        List<ATypeRepresentation> GetRootTypes();
        List<ATypeRepresentation> GetChildrenForType(ATypeRepresentation typePlaceholder);
    }
}
