
namespace Exhibition.Core
{
    using System;
    using Exhibition.Core.Models;
    public delegate void OperationEventHandler(object sender, OperatorEventArgs e);
    public class Host
    {
        public static event OperationEventHandler Operate;
        public static void TriggerOperationEvent(object sender, OperationTypes type, Resource resource)
        {
            if (Operate != null)
            {
                Operate(sender, new OperatorEventArgs() { Type = type, Resource = resource });
            }
        }
    }
}
