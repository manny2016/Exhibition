using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exhibition.Core;
using Exhibition.Core.Configuration;

namespace Exhibition
{
    public partial class FrmConsole : Form
    {
        public FrmConsole()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var settings =ExhibitionConfiguration.GetSettings();
            var navs = ExhibitionConfiguration.GenernateNavigations().ToArray();
        }
    }
}
