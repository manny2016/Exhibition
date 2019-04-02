


namespace Exhibition.Core
{


    using Exhibition.Core.Models;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    [ServiceContract]

    public interface IOperationService
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,            
            ResponseFormat = WebMessageFormat.Json)]
        void Play(Resource resource);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        new void Stop();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        Resource[] Query(string name);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        Navigation[] GetNavigations();
    }
}
