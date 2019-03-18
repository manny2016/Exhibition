using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Exhibition.Core.Configuration;
using Exhibition.Core.Models;

namespace Exhibition.Core.Services
{


    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OperationService : IOperationService
    {

        public Navigation[] GetNavigations()
        {
            return ExhibitionConfiguration.GenernateNavigations()
                .ToArray();
        }

        public void Play(Resource resource)
        {
            Host.TriggerOperationEvent(this, OperationTypes.Play, resource);
        }

        public void Stop()
        {
            Host.TriggerOperationEvent(this, OperationTypes.Stop, null);
        }
    }
}
