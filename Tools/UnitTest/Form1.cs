using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestAnsy();
        }
        private async Task<int> TestAnsy()
        {
            for (int i = 0; i < 100; i++)
            {
                Debug.Print($"I = {i}");
            }
            
            return  100;
        }
    }
}
