using System;
using System.ServiceModel.Configuration;

namespace Exhibition.Core
{
    public class NewtonsoftJsonBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof ( NewtonsoftJsonBehavior ); }
        }

        protected override object CreateBehavior()
        {
            return new NewtonsoftJsonBehavior();
        }
    }
}