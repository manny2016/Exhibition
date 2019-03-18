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
    public partial class FrmContainer : Form
    {
        public FrmContainer()
        {
            InitializeComponent();
            this.Load += FrmContainer_Load;
            Host.Operate += Host_Operate;
        }

        private void Host_Operate(object sender, Core.Models.OperatorEventArgs e)
        {

        }

        private void FrmContainer_Load(object sender, EventArgs e)
        {

        }
    }
}
