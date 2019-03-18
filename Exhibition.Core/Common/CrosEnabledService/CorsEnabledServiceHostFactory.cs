

namespace Exhibition.Core.CrosEnabledService
{
    //https://code.msdn.microsoft.com/Implementing-CORS-support-c1f9cd4b/sourcecode?fileId=57447&pathId=1884302858
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Web;
    public class CorsEnabledServiceHostFactory : ServiceHostFactory
    {

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new CorsEnabledServiceHost(serviceType, baseAddresses);
        }

       
    }
   
}
