using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ViewModel;

namespace View
{
    class XmlFileOpener : IFilePathChooser
    {
        public string GetPathToFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"E:\";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }
    }
}
