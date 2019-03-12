using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Exhibition.Core
{
    public class EnableCorsEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var corsEnabledOperations = endpoint.Contract.Operations
                .SelectMany(o => o.OperationBehaviors.Select(f => f as OperationDescription))
                .ToList();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CorsEnabledMessageInspector(corsEnabledOperations));
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
