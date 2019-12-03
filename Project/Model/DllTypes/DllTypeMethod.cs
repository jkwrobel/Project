using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.DllTypes
{
    class DllTypeMethod : ATypeRepresentation
    {
        private MethodInfo _repMethodInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeMethod(MethodInfo repMethodInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repMethodInfo = repMethodInfo;
            RepresentationType = DllType.Method;
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                _addParameters(_repMethodInfo);
                _addReturnType(_repMethodInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addParameters(MethodInfo repMethodInfo)
        {
            foreach (ParameterInfo parameterInfo in repMethodInfo.GetParameters())
            {
                ReferencedTypes.Add(new DllTypeParameter(parameterInfo));
            }
        }

        private void _addReturnType(MethodInfo repMethodInfo)
        {
            ReferencedTypes.Add(new DllTypeReturn(repMethodInfo.ReturnParameter));
        }

        public override string Name
        {
            get { return _repMethodInfo.ToString(); }
            set
            {

            }
        }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
