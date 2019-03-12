using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core.Configuration
{
    public class Settings
    {
        [Newtonsoft.Json.JsonProperty("locates")]
        public Locator[] Locates { get; set; }
        [Newtonsoft.Json.JsonProperty("defaultMonitor")]
        public int DefaultMonitor { get; set; }
    }
}
