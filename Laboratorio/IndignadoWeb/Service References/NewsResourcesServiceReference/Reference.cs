﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.NewsResourcesServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTRssItemsCol", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTRssItemsCol : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.NewsResourcesServiceReference.DTRssItem[] itemsField;
        
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
        public IndignadoWeb.NewsResourcesServiceReference.DTRssItem[] items {
            get {
                return this.itemsField;
            }
            set {
                if ((object.ReferenceEquals(this.itemsField, value) != true)) {
                    this.itemsField = value;
                    this.RaisePropertyChanged("items");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTRssItem", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTRssItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sourceTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sourceUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string titleField;
        
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
        public string date {
            get {
                return this.dateField;
            }
            set {
                if ((object.ReferenceEquals(this.dateField, value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string sourceText {
            get {
                return this.sourceTextField;
            }
            set {
                if ((object.ReferenceEquals(this.sourceTextField, value) != true)) {
                    this.sourceTextField = value;
                    this.RaisePropertyChanged("sourceText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string sourceUrl {
            get {
                return this.sourceUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.sourceUrlField, value) != true)) {
                    this.sourceUrlField = value;
                    this.RaisePropertyChanged("sourceUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                if ((object.ReferenceEquals(this.titleField, value) != true)) {
                    this.titleField = value;
                    this.RaisePropertyChanged("title");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NewsResourcesServiceReference.INewsResourcesService")]
    public interface INewsResourcesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/getResourcesList", ReplyAction="http://tempuri.org/INewsResourcesService/getResourcesListResponse")]
        IndignadoWeb.NewsResourcesServiceReference.DTRssItemsCol getResourcesList();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INewsResourcesServiceChannel : IndignadoWeb.NewsResourcesServiceReference.INewsResourcesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NewsResourcesServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.NewsResourcesServiceReference.INewsResourcesService>, IndignadoWeb.NewsResourcesServiceReference.INewsResourcesService {
        
        public NewsResourcesServiceClient() {
        }
        
        public NewsResourcesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NewsResourcesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsResourcesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsResourcesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IndignadoWeb.NewsResourcesServiceReference.DTRssItemsCol getResourcesList() {
            return base.Channel.getResourcesList();
        }
    }
}
