﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class MainWindow : Form
    {
        public MainWindow(string lorInstallPath)
        {
            InitializeComponent();
            lorInstallPathTextField.Text = lorInstallPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}