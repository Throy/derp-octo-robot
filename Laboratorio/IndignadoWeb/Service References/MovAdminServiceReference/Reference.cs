﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.MovAdminServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTMovement", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTMovement : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string adminMailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string adminNickField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string adminPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float locationLatiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float locationLongField;
        
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
        public string adminMail {
            get {
                return this.adminMailField;
            }
            set {
                if ((object.ReferenceEquals(this.adminMailField, value) != true)) {
                    this.adminMailField = value;
                    this.RaisePropertyChanged("adminMail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string adminNick {
            get {
                return this.adminNickField;
            }
            set {
                if ((object.ReferenceEquals(this.adminNickField, value) != true)) {
                    this.adminNickField = value;
                    this.RaisePropertyChanged("adminNick");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string adminPassword {
            get {
                return this.adminPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.adminPasswordField, value) != true)) {
                    this.adminPasswordField = value;
                    this.RaisePropertyChanged("adminPassword");
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
        public float locationLati {
            get {
                return this.locationLatiField;
            }
            set {
                if ((this.locationLatiField.Equals(value) != true)) {
                    this.locationLatiField = value;
                    this.RaisePropertyChanged("locationLati");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float locationLong {
            get {
                return this.locationLongField;
            }
            set {
                if ((this.locationLongField.Equals(value) != true)) {
                    this.locationLongField = value;
                    this.RaisePropertyChanged("locationLong");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MovAdminServiceReference.IMovAdminService")]
    public interface IMovAdminService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovAdminService/getMovement", ReplyAction="http://tempuri.org/IMovAdminService/getMovementResponse")]
        IndignadoWeb.MovAdminServiceReference.DTMovement getMovement(int idMovement);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovAdminService/setMovement", ReplyAction="http://tempuri.org/IMovAdminService/setMovementResponse")]
        void setMovement(IndignadoWeb.MovAdminServiceReference.DTMovement dtMovement);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMovAdminServiceChannel : IndignadoWeb.MovAdminServiceReference.IMovAdminService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MovAdminServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.MovAdminServiceReference.IMovAdminService>, IndignadoWeb.MovAdminServiceReference.IMovAdminService {
        
        public MovAdminServiceClient() {
        }
        
        public MovAdminServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MovAdminServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MovAdminServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MovAdminServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IndignadoWeb.MovAdminServiceReference.DTMovement getMovement(int idMovement) {
            return base.Channel.getMovement(idMovement);
        }
        
        public void setMovement(IndignadoWeb.MovAdminServiceReference.DTMovement dtMovement) {
            base.Channel.setMovement(dtMovement);
        }
    }
}
