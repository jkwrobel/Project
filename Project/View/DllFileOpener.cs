using Microsoft.Win32;
using ViewModel;

namespace View
{
    internal class DllFileOpener : IFilePathChooser
    {
        public string GetPathToFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"E:\";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "dll";
            openFileDialog.Filter = "Dll Files|*.dll";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }
    }
}