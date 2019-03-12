

using Exhibition.Core.Models;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Exhibition.Core
{
    [ServiceContract]
    
    public interface IOperationService
    {

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,ResponseFormat = WebMessageFormat.Json,
            Method = "POST"), OperationContract, CorsEnabled]
        
        void Play(Resource resource);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest), OperationContract, CorsEnabled]

        void Stop();



        [WebGet(ResponseFormat = WebMessageFormat.Json), OperationContract, CorsEnabled]
        Navigation[] GetNavigations();
    }
}
