﻿using System.Collections.Generic;
using System.Reflection;

namespace Model.DllTypes
{
    internal class DllTypeReturn : ATypeRepresentation
    {
        private ParameterInfo _repParameterInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeReturn(ParameterInfo repParameterInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repParameterInfo = repParameterInfo;
            RepresentationType = DllType.Return;
            Name = GenerateName();
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                //if (_repParameterInfo.ParameterType.Namespace != null && _repParameterInfo.ParameterType.Namespace.Contains("System"))
                //{
                //    _addReturnType(_repParameterInfo, true);
                //    _referencedTypesGenerated = true;
                //    return true;
                //}
                _addReturnType(_repParameterInfo, false);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addReturnType(ParameterInfo repParameterInfo, bool doShallow)
        {
            if (!DllTypeManager.RememberedTypesDictionary.ContainsKey(repParameterInfo.ParameterType.GUID))
            {
                if(doShallow) return;
                DllTypeManager.RememberedTypesDictionary.Add(repParameterInfo.ParameterType.GUID, new DllTypeClass(repParameterInfo.ParameterType));
            }
            ReferencedTypes.Add(DllTypeManager.RememberedTypesDictionary[repParameterInfo.ParameterType.GUID]);

        }

        private string GenerateName()
        {
            string name = "";

            name += "Return ";
            name += _repParameterInfo.ParameterType.Name;
            name += _repParameterInfo.Name;
            return name;
        }

        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _name;

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
