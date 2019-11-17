using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    static class PlaceholderForTypeManagement
    {
        private static Random _random = new Random();
        public static List<TypePlaceholder> PlaceholderGetTypesForType(String typePlaceholder)
        {
            List<TypePlaceholder> typePlaceholders = new List<TypePlaceholder>();
            int numberOfChildren = _random.Next(1, 4);
            for (int i = 0; i < numberOfChildren; i++)
            {
                TypePlaceholder tempType = new TypePlaceholder()
                {
                    Name = typePlaceholder + i
                };

                typePlaceholders.Add(tempType);
            }

            return typePlaceholders;
        }
    }
}
