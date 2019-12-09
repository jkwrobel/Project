using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public abstract class ATypeRepresentation
    {
        [DataMember]
        public abstract string Name { get; set; }

        public abstract bool GenerateReferencedTypes();

        public bool RecursiveLevelGeneration(int currentLevel, int targetLevel)
        {
            if (targetLevel >= 10)
            {
                return false;
            }

            if (currentLevel == targetLevel)
            {
                return GenerateReferencedTypes();
            }
            else
            {
                bool anyTrueHolder = false;
                foreach (ATypeRepresentation referencedType in ReferencedTypes)
                {
                    if (referencedType.RecursiveLevelGeneration(currentLevel + 1, targetLevel))
                    {
                        anyTrueHolder = true;
                    }
                }

                return anyTrueHolder;
            }
        }

        [DataMember]
        public DllType RepresentationType;

        [DataMember]
        public abstract List<ATypeRepresentation> ReferencedTypes { get; set; }

        [DataMember]
        protected List<ATypeRepresentation> _referencedTypes = null;

        [DataMember]
        protected string _name;
    }

    public enum DllType
    {
        Class, Field, Method, Property, Return, Constructor
    }
}
