using ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ViewModel.Tests
{
    [TestClass()]
    public class ViewModelBaseTests
    {
        [TestMethod()]
        public void TreeViewTypeElementTest()
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
        public void TreeViewTypeElementTest()
        {
            TreeViewViewModel treeViewViewModel = new TreeViewViewModel();
            Assert.AreEqual(new ObservableCollection<TreeViewTypeElement>().GetType(),
            treeViewViewModel.ReferencedTypes.GetType());
            Assert.IsTrue(treeViewViewModel.ReferencedTypes.Count > 0);
        }
    }

    [TestClass()]
    public class TreeViewTypeElementTests
    {
        [TestMethod()]
        public void TreeViewTypeElementTest()
        {
            throw new NotImplementedException();
        }
    }
}
