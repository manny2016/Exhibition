


namespace Exhibition.Core
{


    using Exhibition.Core.Models;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    [ServiceContract(Namespace = "http://exhibition.core.OperationService")]

    public interface IOperationService : IOperate
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        void Play(string name,string displayName,ResourceType type,string fullName);


        //[DataMember]
        //public string Name { get; set; }


        //[DataMember]
        //public string DisplayName { get; set; }


        //[DataMember]
        //public ResourceType Type { get; set; }


        //[DataMember]
        //public string FullName { get; set; }

        //[DataMember]

        //public string ImageUrl { get; set; }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new void Stop();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Resource[] Query(string name);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Navigation[] GetNavigations();
    }
}
