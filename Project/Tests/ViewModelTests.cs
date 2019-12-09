﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
            treeViewViewModel.TypeManagerInst = new DllTypeManager();
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
        [TestMethod()]
        public void AssignTypeManagerCommandTest()
        {
            TreeViewViewModel treeViewViewModel = new TreeViewViewModel();

            Assert.IsNull(treeViewViewModel.TypeManagerInst);
            treeViewViewModel.AssignDataSourceRandom.Execute(this);
            Assert.IsNotNull(treeViewViewModel.TypeManagerInst);
        }
    }
}
