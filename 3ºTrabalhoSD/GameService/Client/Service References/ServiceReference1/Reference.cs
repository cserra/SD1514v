﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMyTranslator")]
    public interface IMyTranslator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyTranslator/Translate", ReplyAction="http://tempuri.org/IMyTranslator/TranslateResponse")]
        string Translate(string frase, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyTranslator/Translate", ReplyAction="http://tempuri.org/IMyTranslator/TranslateResponse")]
        System.Threading.Tasks.Task<string> TranslateAsync(string frase, string to);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyTranslatorChannel : Client.ServiceReference1.IMyTranslator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyTranslatorClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IMyTranslator>, Client.ServiceReference1.IMyTranslator {
        
        public MyTranslatorClient() {
        }
        
        public MyTranslatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyTranslatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyTranslatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyTranslatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Translate(string frase, string to) {
            return base.Channel.Translate(frase, to);
        }
        
        public System.Threading.Tasks.Task<string> TranslateAsync(string frase, string to) {
            return base.Channel.TranslateAsync(frase, to);
        }
    }
}
