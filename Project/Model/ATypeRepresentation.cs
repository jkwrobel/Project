using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ATypeRepresentation
    {
        public abstract string Name { get; set; }

        public abstract List<ATypeRepresentation> ReferencedTypes { get; set; }

        protected List<ATypeRepresentation> _referencedTypes = null;
        protected string _name;
    }
}
