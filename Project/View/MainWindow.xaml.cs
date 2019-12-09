﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            TreeViewViewModel treeViewViewModel = new TreeViewViewModel();
            DataContext = treeViewViewModel;
            treeViewViewModel.FileXmlPathOpener = new XmlFileOpener();
            treeViewViewModel.FilePathCreator = new XmlFileCreator();
            treeViewViewModel.FileDllPathOpener = new DllFileOpener();
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //TreeViewViewModel treeViewViewModel = (TreeViewViewModel)DataContext;
        }
    }
}
