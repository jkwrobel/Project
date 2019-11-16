using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class PlaceholderForTypeManagement
    {
        List<TypePlaceholder> PlaceholderGetTypesForType(TypePlaceholder typePlaceholder)
        {
            List<TypePlaceholder> typePlaceholders = new List<TypePlaceholder>();
            int numberOfChildren = new Random().Next(1, 4);
            for (int i = 0; i < numberOfChildren; i++)
            {
                TypePlaceholder tempType = new TypePlaceholder()
                {
                    Name = "TempName" + i
                };

                typePlaceholders.Add(tempType);
            }

            return typePlaceholders;
        }
    }
}
