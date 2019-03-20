using System;
using System.Collections.Generic;

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
