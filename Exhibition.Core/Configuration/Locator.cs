using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core.Configuration
{
    public class Locator
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [Newtonsoft.Json.JsonProperty("root")]
        public string Root { get; set; }
    }
}
