using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Core.Models
{

    [DataContract]
    
    public class Navigation
    {
        
        [DataMember(Name ="name")]
        public string Name { get; set; }


        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }


        [DataMember(Name = "resLocation")]
        public string ResLocation { get; set; }

        [DataMember(Name = "children")]

        public Navigation[] Children { get; set; }

        [DataMember(Name = "resources")]

        public Resource[] Resources { get; set; }
    }
}
