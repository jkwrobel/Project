﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TypeManager : ITypeManager
    {
        public List<TypePlaceholder> GetRootTypes()
        {
            return PlaceholderForTypeManagement.PlaceholderGetTypesForType();
        }
    }
}
