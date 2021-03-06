﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Console.Endpoint {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://exhibition.core.OperationService", ConfigurationName="Endpoint.IOperationService")]
    public interface IOperationService {
        
        // CODEGEN: Generating message contract since the operation Play is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/Play", ReplyAction="http://exhibition.core.OperationService/IOperationService/PlayResponse")]
        Console.Endpoint.PlayResponse Play(Console.Endpoint.Resource request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/Play", ReplyAction="http://exhibition.core.OperationService/IOperationService/PlayResponse")]
        System.Threading.Tasks.Task<Console.Endpoint.PlayResponse> PlayAsync(Console.Endpoint.Resource request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/Stop", ReplyAction="http://exhibition.core.OperationService/IOperationService/StopResponse")]
        void Stop();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/Stop", ReplyAction="http://exhibition.core.OperationService/IOperationService/StopResponse")]
        System.Threading.Tasks.Task StopAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/Query", ReplyAction="http://exhibition.core.OperationService/IOperationService/QueryResponse")]
        Exhibition.Core.Models.Resource[] Query(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/Query", ReplyAction="http://exhibition.core.OperationService/IOperationService/QueryResponse")]
        System.Threading.Tasks.Task<Exhibition.Core.Models.Resource[]> QueryAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/GetNavigations", ReplyAction="http://exhibition.core.OperationService/IOperationService/GetNavigationsResponse")]
        Exhibition.Core.Models.Navigation[] GetNavigations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://exhibition.core.OperationService/IOperationService/GetNavigations", ReplyAction="http://exhibition.core.OperationService/IOperationService/GetNavigationsResponse")]
        System.Threading.Tasks.Task<Exhibition.Core.Models.Navigation[]> GetNavigationsAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Resource", WrapperNamespace="http://exhibition.core.OperationService", IsWrapped=true)]
    public partial class Resource {
        
        public Resource() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PlayResponse {
        
        public PlayResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOperationServiceChannel : Console.Endpoint.IOperationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperationServiceClient : System.ServiceModel.ClientBase<Console.Endpoint.IOperationService>, Console.Endpoint.IOperationService {
        
        public OperationServiceClient() {
        }
        
        public OperationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OperationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Console.Endpoint.PlayResponse Console.Endpoint.IOperationService.Play(Console.Endpoint.Resource request) {
            return base.Channel.Play(request);
        }
        
        public void Play() {
            Console.Endpoint.Resource inValue = new Console.Endpoint.Resource();
            Console.Endpoint.PlayResponse retVal = ((Console.Endpoint.IOperationService)(this)).Play(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Console.Endpoint.PlayResponse> Console.Endpoint.IOperationService.PlayAsync(Console.Endpoint.Resource request) {
            return base.Channel.PlayAsync(request);
        }
        
        public System.Threading.Tasks.Task<Console.Endpoint.PlayResponse> PlayAsync() {
            Console.Endpoint.Resource inValue = new Console.Endpoint.Resource();
            return ((Console.Endpoint.IOperationService)(this)).PlayAsync(inValue);
        }
        
        public void Stop() {
            base.Channel.Stop();
        }
        
        public System.Threading.Tasks.Task StopAsync() {
            return base.Channel.StopAsync();
        }
        
        public Exhibition.Core.Models.Resource[] Query(string name) {
            return base.Channel.Query(name);
        }
        
        public System.Threading.Tasks.Task<Exhibition.Core.Models.Resource[]> QueryAsync(string name) {
            return base.Channel.QueryAsync(name);
        }
        
        public Exhibition.Core.Models.Navigation[] GetNavigations() {
            return base.Channel.GetNavigations();
        }
        
        public System.Threading.Tasks.Task<Exhibition.Core.Models.Navigation[]> GetNavigationsAsync() {
            return base.Channel.GetNavigationsAsync();
        }
    }
}
