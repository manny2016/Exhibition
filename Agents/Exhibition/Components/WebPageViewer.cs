using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exhibition.Core;
using Exhibition.Core.Models;

namespace Exhibition.Components
{
    public partial class WebPageViewer : UserControl, IOperationService
    {
        public WebPageViewer()
        {
            InitializeComponent();
        }

        public Navigation[] GetNavigations()
        {
            throw new NotImplementedException();
        }

        public void Play(Resource resource)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
