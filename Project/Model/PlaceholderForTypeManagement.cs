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
        private static readonly string []RootNames = new [] { "First", "Second", "Third"};
        private static readonly Random InstRandom = new Random();
        public static List<TypePlaceholder> PlaceholderGetTypesForType()
        {
            List<TypePlaceholder> typePlaceholders = new List<TypePlaceholder>();
            int numberOfChildren = InstRandom.Next(1, 4);
            for (int i = 0; i < numberOfChildren; i++)
            {
                TypePlaceholder tempType = new TypePlaceholder()
                {
                    Name = RootNames[(i+InstRandom.Next(0,3))%3] + i
                };

                typePlaceholders.Add(tempType);
            }

            return typePlaceholders;
        }
    }
}
