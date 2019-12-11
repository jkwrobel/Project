using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace ViewModel
{
    [TestClass()]
    public class ViewModelBaseTests
    {
        [TestMethod()]
        public void ViewModelBaseTest()
        {
            ViewModelBaseTestClass testClass = new ViewModelBaseTestClass();
            bool hasBeenRaised = false;
            string raisedPropertyName = "";
            testClass.PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
            {
                hasBeenRaised = true;
                raisedPropertyName = args.PropertyName;
            };
            testClass.RaisePropertyChangerTestMethod("testName");
            Assert.IsTrue(hasBeenRaised);
            Assert.AreEqual("testName", raisedPropertyName);
        }

        private class ViewModelBaseTestClass : ViewModelBase
        {
            public void RaisePropertyChangerTestMethod(string propertyName)
            {
                base.OnPropertyChanged(propertyName);
            }
        }
    }

    [TestClass()]
    public class TreeViewViewModelTests
    {
        [TestMethod()]
        public void TreeViewViewModelTest()
        {
            TreeViewViewModel treeViewViewModel = new TreeViewViewModel();
            Assert.AreEqual(new ObservableCollection<TreeViewTypeElement>().GetType(),
            treeViewViewModel.ReferencedTypes.GetType());
            Assert.IsFalse(treeViewViewModel.HasTypeManager);
            DllTypeManager dllTypeManager = new DllTypeManager();
            string pathToTest = Environment.CurrentDirectory;
            for (int i = 0; i < 4; i++)
            {
                pathToTest = Directory.GetParent(pathToTest).FullName;
            }
            dllTypeManager.AssignPathToFile(Path.Combine(pathToTest, "testData\\TPA.ApplicationArchitecture.dll"));
            dllTypeManager.InitTypeManager();
            treeViewViewModel.TypeManagerInst = dllTypeManager;
            Assert.IsTrue(treeViewViewModel.ReferencedTypes.Count == 0);
            
            treeViewViewModel.ShowTreeViewCommand.Execute(this);
            Assert.IsTrue(treeViewViewModel.ReferencedTypes.Count > 0);
        }
    }

    [TestClass()]
    public class TreeViewTypeElementTests
    {
        [TestMethod()]
        public void TreeViewTypeElementTest()
        {

        }
    }
    [TestClass()]
    public class ShowTreeViewCommandTests
    {
        public class TreeViewViewModelTest : TreeViewViewModel
        {
            public bool RootsGenerated = false;


            public override void GenerateRoots()
            {
                RootsGenerated = true;
            }
        }

        [TestMethod()]
        public void ShowTreeViewCommandTest()
        {
            TreeViewViewModelTest treeViewViewModel = new TreeViewViewModelTest();
            ShowTreeViewCommand showTreeViewCommand = new ShowTreeViewCommand(treeViewViewModel);
            Assert.IsFalse(treeViewViewModel.RootsGenerated);
            treeViewViewModel.HasTypeManager = true;
            showTreeViewCommand.Execute(this);
            Assert.IsTrue(treeViewViewModel.RootsGenerated);

        }
    }

    [TestClass()]
    public class AssignTypeManagerCommandTests
    {
        public class TempFilePathOpener : IFilePathChooser
        {
            public string GetPathToFile()
            {
                string pathToTest = Environment.CurrentDirectory;
                for (int i = 0; i < 4; i++)
                {
                    pathToTest = Directory.GetParent(pathToTest).FullName;
                }
                return Path.Combine(pathToTest, "testData\\TPA.ApplicationArchitecture.dll");
            }
        }
        [TestMethod()]
        public void AssignTypeManagerCommandTest()
        {
            TreeViewViewModel treeViewViewModel = new TreeViewViewModel();

            Assert.IsNull(treeViewViewModel.TypeManagerInst);
            treeViewViewModel.FileDllPathOpener = new TempFilePathOpener();
            treeViewViewModel.WriteMetadataToXml = new WriteMetadataToXml(treeViewViewModel);
            treeViewViewModel.AssignDataSourceDll.Execute(this);
            Assert.IsNotNull(treeViewViewModel.TypeManagerInst);
        }
    }

    [TestClass]
    public class IFilePathChooserTests
    {
        class TestFilePathChooser : IFilePathChooser
        {
            public string GetPathToFile()
            {
                return "@C:\\";
            }
        }

        [TestMethod]
        public void IFilePathChooserTest()
        {
            IFilePathChooser filePathChooser = new TestFilePathChooser();
            Assert.AreEqual("@C:\\", filePathChooser.GetPathToFile());
        }
    }
}
