﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.530
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.SysAdminServiceReference {
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
        private double locationLatiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double locationLongField;
        
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
        public double locationLati {
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
        public double locationLong {
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTMovementsCol", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTMovementsCol : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.SysAdminServiceReference.DTMovement[] itemsField;
        
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
        public IndignadoWeb.SysAdminServiceReference.DTMovement[] items {
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SysAdminServiceReference.ISysAdminService")]
    public interface ISysAdminService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISysAdminService/createMovement", ReplyAction="http://tempuri.org/ISysAdminService/createMovementResponse")]
        void createMovement(IndignadoWeb.SysAdminServiceReference.DTMovement dtMovement);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISysAdminService/getMovementsList", ReplyAction="http://tempuri.org/ISysAdminService/getMovementsListResponse")]
        IndignadoWeb.SysAdminServiceReference.DTMovementsCol getMovementsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISysAdminService/enableMovement", ReplyAction="http://tempuri.org/ISysAdminService/enableMovementResponse")]
        void enableMovement();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISysAdminService/disableMovement", ReplyAction="http://tempuri.org/ISysAdminService/disableMovementResponse")]
        void disableMovement();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISysAdminServiceChannel : IndignadoWeb.SysAdminServiceReference.ISysAdminService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SysAdminServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.SysAdminServiceReference.ISysAdminService>, IndignadoWeb.SysAdminServiceReference.ISysAdminService {
        
        public SysAdminServiceClient() {
        }
        
        public SysAdminServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SysAdminServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SysAdminServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SysAdminServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void createMovement(IndignadoWeb.SysAdminServiceReference.DTMovement dtMovement) {
            base.Channel.createMovement(dtMovement);
        }
        
        public IndignadoWeb.SysAdminServiceReference.DTMovementsCol getMovementsList() {
            return base.Channel.getMovementsList();
        }
        
        public void enableMovement() {
            base.Channel.enableMovement();
        }
        
        public void disableMovement() {
            base.Channel.disableMovement();
        }
    }
}
