﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.530
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.SessionServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTTenantInfo", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTTenantInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool habilitadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string layoutFileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string logoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool habilitado {
            get {
                return this.habilitadoField;
            }
            set {
                if ((this.habilitadoField.Equals(value) != true)) {
                    this.habilitadoField = value;
                    this.RaisePropertyChanged("habilitado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string layoutFile {
            get {
                return this.layoutFileField;
            }
            set {
                if ((object.ReferenceEquals(this.layoutFileField, value) != true)) {
                    this.layoutFileField = value;
                    this.RaisePropertyChanged("layoutFile");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string logo {
            get {
                return this.logoField;
            }
            set {
                if ((object.ReferenceEquals(this.logoField, value) != true)) {
                    this.logoField = value;
                    this.RaisePropertyChanged("logo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SessionServiceReference.ISessionService")]
    public interface ISessionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISessionService/Login", ReplyAction="http://tempuri.org/ISessionService/LoginResponse")]
        string Login(int idMovmiento, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISessionService/GetTenantInfo", ReplyAction="http://tempuri.org/ISessionService/GetTenantInfoResponse")]
        IndignadoWeb.SessionServiceReference.DTTenantInfo GetTenantInfo(string movimiento);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISessionServiceChannel : IndignadoWeb.SessionServiceReference.ISessionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SessionServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.SessionServiceReference.ISessionService>, IndignadoWeb.SessionServiceReference.ISessionService {
        
        public SessionServiceClient() {
        }
        
        public SessionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SessionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SessionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SessionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Login(int idMovmiento, string userName, string password) {
            return base.Channel.Login(idMovmiento, userName, password);
        }
        
        public IndignadoWeb.SessionServiceReference.DTTenantInfo GetTenantInfo(string movimiento) {
            return base.Channel.GetTenantInfo(movimiento);
        }
    }
}
