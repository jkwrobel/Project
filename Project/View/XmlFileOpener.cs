using System;
using Microsoft.Win32;
using ViewModel;

namespace View
{
    internal class XmlFileOpener : IFilePathChooser
    {
        public string GetPathToFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "")
            {
                throw new ArgumentException("No file has been chosen");
            }
            return openFileDialog.FileName;
        }
    }
}
