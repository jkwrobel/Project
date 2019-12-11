using System;
using Microsoft.Win32;
using ViewModel;

namespace View
{
    internal class XmlFileCreator : IFilePathChooser
    {
        public string GetPathToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML Files|*.xml";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
            {
                throw new ArgumentException("No file has been chosen");
            }
            return saveFileDialog.FileName;
        }
    }
}