using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TypeManager
    {
        public ObservableCollection<TypePlaceholder> GetTypePlaceholdersForTypePlaceholder(
            TypePlaceholder typePlaceholder)
        {
            return PlaceholderForTypeManagement.PlaceholderGetTypesForType(typePlaceholder);
        }
    }
}
