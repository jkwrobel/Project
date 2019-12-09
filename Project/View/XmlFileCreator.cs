using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ViewModel;

namespace View
{
    class XmlFileCreator : IFilePathChooser
    {
        public string GetPathToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"E:\";
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML Files|*.xml";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }
    }
}