using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Exhibition.Core.Models;

namespace Exhibition.Core.Services
{
    public class OperationServiceClient : ClientBase<IOperationService>, IOperationService
    {
        public static OperationServiceClient Create(string ipAddress)
        {
            Binding httpBinding = new BasicHttpBinding() { MaxBufferSize = 4194304, MaxReceivedMessageSize = 4194304, SendTimeout = new TimeSpan(0, 10, 0) };

            EndpointAddress httpAddress = new EndpointAddress("http://localhost:8888/api/OperationService");
            OperationServiceClient client = new OperationServiceClient(httpBinding, httpAddress);
            return client;
        }
        public OperationServiceClient()
            : base()
        { }
        public OperationServiceClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        { }
        public OperationServiceClient(System.ServiceModel.Channels.Binding binding, EndpointAddress address)
            : base(binding, address)
        { }

        public Navigation[] GetNavigations()
        {
            try
            {


                return this.Channel.GetNavigations();
            }
            catch
            {
                return new Navigation[] { };
            }
        }

        public void Play(Resource resource)
        {
            try
            {
                this.Channel.Play(resource);
            }
            catch
            {

            }
        }

        public Resource[] Query(string name)
        {
            try
            {


                return this.Channel.Query(name);
            }
            catch
            {
                return new Resource[] { };
            }

        }

        public void Stop()
        {
            try
            {
                this.Channel.Stop();
            }
            catch
            {

            }
        }

        public void Play(string name, string displayName, ResourceType type, string fullName)
        {
            try
            {
                this.Channel.Play(name, displayName, type, fullName);
            }
            catch
            {

            }
        }
    }
}
