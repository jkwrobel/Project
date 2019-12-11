using System;
using Microsoft.Win32;
using ViewModel;

namespace View
{
    internal class DllFileOpener : IFilePathChooser
    {
        public string GetPathToFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "dll";
            openFileDialog.Filter = "Dll Files|*.dll";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "")
            {
                throw new ArgumentException("No file has been chosen");
            }
            return openFileDialog.FileName;
        }
    }
}