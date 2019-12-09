using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Model.DllTypes;

namespace Model
{
    [DataContract]
    public class DllTypeManager : ITypeManager
    {
        public static Dictionary<Guid,ATypeRepresentation> RememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();

        [DataMember]
        public  Dictionary<Guid, ATypeRepresentation> LocalRememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();

        private Dictionary<Guid, ATypeRepresentation> dictionarySnapshot;

        public DllTypeManager()
        {


        }

        public void InitTypeManager()
        {
            DllReader.LoadConnectionTypes(Directory.GetCurrentDirectory());
            foreach (Type connectionType in DllReader.ConnectionTypes)
            {
                if (RememberedTypesDictionary.ContainsKey(connectionType.GUID))
                {
                    continue;
                }
                RememberedTypesDictionary.Add(connectionType.GUID, new DllTypeClass(connectionType));
            }

            dictionarySnapshot = new Dictionary<Guid, ATypeRepresentation>(DllTypeManager.RememberedTypesDictionary);

            int levelCounter = 0;
            while (RunGenerationForGivenLevel(levelCounter))
            {
                levelCounter++;
            }
        }

        private bool RunGenerationForGivenLevel(int level)
        {
            bool anyTrueHolder = false;
            foreach (ATypeRepresentation typeRepresentation in dictionarySnapshot.Values)
            {
                if (typeRepresentation.RecursiveLevelGeneration(0, level))
                {
                    anyTrueHolder = true;
                }
            }

            return anyTrueHolder;
        }

        public List<ATypeRepresentation> GetRootTypes()
        {
            return RememberedTypesDictionary.Values.ToList();
        }

        public List<ATypeRepresentation> GetChildrenForType(ATypeRepresentation typePlaceholder)
        {
            return typePlaceholder.ReferencedTypes;
        }
    }
}
