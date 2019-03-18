using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core.Models
{
    public class OperatorEventArgs : EventArgs
    {
        public OperationTypes Type { get; set; }
        public Resource Resource { get; set; }
    }
}
