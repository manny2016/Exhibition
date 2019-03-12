using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core.Models
{
    
    public class Navigation
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("displayName")]
        public string DisplayName { get; set; }


        [Newtonsoft.Json.JsonProperty("resLocation", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResLocation { get; set; }

        [Newtonsoft.Json.JsonProperty("children")]

        public Navigation[] Children { get; set; }

        [Newtonsoft.Json.JsonProperty("resources", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        public Resource[] Resources { get; set; }
    }
}
