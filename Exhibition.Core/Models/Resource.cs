



namespace Exhibition.Core.Models
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [DataContract]
    public class Resource
    {
        

        [DataMember(Name="name")]
        public string Name { get; set; }


        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }


        [DataMember(Name = "type")]
        public ResourceType Type { get; set; }


        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        [DataMember(Name = "imageUrl")]

        public string ImageUrl { get; set; }
    }
}
