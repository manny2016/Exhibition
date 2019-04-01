



namespace Exhibition.Core.Models
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [MessageContract]    
    public class Resource
    {

        [DataMember]
        public string Name { get; set; }


        [DataMember]
        public string DisplayName { get; set; }


        [DataMember]
        public ResourceType Type { get; set; }


        [DataMember]
        public string FullName { get; set; }

        [DataMember]

        public string ImageUrl { get; set; }
    }
}
