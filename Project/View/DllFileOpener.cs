﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ViewModel;

namespace View
{
    class DllFileOpener : IFilePathChooser
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