using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Exhibition.Core.Configuration;
using Exhibition.Core.Models;

namespace Exhibition.Core.Services
{

    public class OperationService : IOperationService
    {
        public void Dispose()
        {

        }

        public Navigation[] GetNavigations()
        {
            return ExhibitionConfiguration.GenernateNavigations()
                .ToArray();
        }



        public void Play(string name, string displayName, ResourceType type, string fullName)
        {
            var resource = new Resource() { Name = name, DisplayName = displayName, Type = type, FullName = fullName };
            Host.TriggerOperationEvent(this, OperationTypes.Play, resource);
        }

        public void Play(Resource resource)
        {
            throw new NotImplementedException();
        }

        public Resource[] Query(string name)
        {
            var settings = ExhibitionConfiguration.GetSettings();
            var locator = settings.Locates.FirstOrDefault(o => o.Name == name);
            if (locator == null) throw new KeyNotFoundException(name);
            return ExhibitionConfiguration.LoadResource(locator).Resources;
        }

        public void Stop()
        {
            Host.TriggerOperationEvent(this, OperationTypes.Stop, null);
        }
    }
}
