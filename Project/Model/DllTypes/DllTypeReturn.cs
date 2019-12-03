using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.DllTypes
{
    class DllTypeReturn : ATypeRepresentation
    {
        private ParameterInfo _repParameterInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeReturn(ParameterInfo repParameterInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repParameterInfo = repParameterInfo;
            
            RepresentationType = DllType.Return;
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                if (_repParameterInfo.ParameterType.Namespace != null && _repParameterInfo.ParameterType.Namespace.Contains("System"))
                {
                    _referencedTypesGenerated = true;
                    return true;
                }
                _addReturnType(_repParameterInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addReturnType(ParameterInfo repParameterInfo)
        {
            if (!DllTypeManager.RememberedTypesDictionary.ContainsKey(repParameterInfo.ParameterType.GUID))
            {
                DllTypeManager.RememberedTypesDictionary.Add(repParameterInfo.ParameterType.GUID,new DllTypeClass(repParameterInfo.ParameterType));
            }
            ReferencedTypes.Add(DllTypeManager.RememberedTypesDictionary[repParameterInfo.ParameterType.GUID]);
        }

        public override string Name
        {
            get { return _repParameterInfo.ToString(); }
            set
            {

            }
        }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
