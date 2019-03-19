using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core.Models
{

    public class Resource
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public ResourceType Type { get; set; }

        [Newtonsoft.Json.JsonProperty("fullName")]
        public string FullName { get; set; }

        [Newtonsoft.Json.JsonProperty("imageUrl", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }
    }
}
