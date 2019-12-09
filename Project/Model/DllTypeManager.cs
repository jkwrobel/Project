using Model.DllTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class DllTypeManager : TypeDictionaryHolder, ITypeManager
    {
        public static Dictionary<Guid, ATypeRepresentation> RememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();
        private string _pathToFile = @"E:\Test.Xml";


        private Dictionary<Guid, ATypeRepresentation> dictionarySnapshot;


        public void InitTypeManager()
        {
            DllReader.LoadConnectionTypes(_pathToFile);
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
            LocalRememberedTypesDictionary = RememberedTypesDictionary;
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

        public void AssignPathToFile(string pathToFile)
        {
            _pathToFile = pathToFile;
        }
    }
}
