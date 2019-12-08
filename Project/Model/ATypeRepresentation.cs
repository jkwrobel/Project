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

        public DllType RepresentationType;

        public abstract List<ATypeRepresentation> ReferencedTypes { get; set; }

        protected List<ATypeRepresentation> _referencedTypes = null;
        protected string _name;
    }

    public enum DllType
    {
        Class, Field, Method, Property, Return, Constructor
    }
}
