using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.DllTypes
{
    class DllTypeConstructor : ATypeRepresentation
    {
        private ConstructorInfo _repConstructorInfo;
        private bool _referencedTypesGenerated = false;
        public DllTypeConstructor(ConstructorInfo repConstructorInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repConstructorInfo = repConstructorInfo;
            RepresentationType = DllType.Constructor;
            
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                _addAttributes(_repConstructorInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addAttributes(ConstructorInfo constructorInfo)
        {
            foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
            {
                ReferencedTypes.Add(new DllTypeParameter(parameterInfo));
            }
        }

        public override string Name
        {
            get { return _repConstructorInfo.ToString(); }
            set
            {

            }
        }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
    
}
