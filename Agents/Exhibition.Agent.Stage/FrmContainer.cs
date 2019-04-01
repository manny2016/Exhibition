using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exhibition.Agent.Stage
{
    public partial class FrmContainer : Form
    {
        public FrmContainer()
        {
            InitializeComponent();
            this.button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.axOfficeViewer1.SlideShowExit();
            this.axOfficeViewer1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.axOfficeViewer1.SlideShowOpenAndPlay(@"d:\Presentation1.pptx",false,false,false,false);
        }
    }
}
