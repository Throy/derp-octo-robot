﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.UsersServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTThemeCategoriesColUsers", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTThemeCategoriesColUsers : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers[] itemsField;
        
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
        public IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers[] items {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTThemeCategoryUsers", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTThemeCategoryUsers : IndignadoWeb.UsersServiceReference.DTThemeCategory {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTThemeCategory", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers))]
    public partial class DTThemeCategory : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idMovementField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int myInterestField;
        
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
        public int idMovement {
            get {
                return this.idMovementField;
            }
            set {
                if ((this.idMovementField.Equals(value) != true)) {
                    this.idMovementField = value;
                    this.RaisePropertyChanged("idMovement");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int myInterest {
            get {
                return this.myInterestField;
            }
            set {
                if ((this.myInterestField.Equals(value) != true)) {
                    this.myInterestField = value;
                    this.RaisePropertyChanged("myInterest");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTUser", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(IndignadoWeb.UsersServiceReference.DTUser_Users))]
    public partial class DTUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool bannedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float locationLatiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float locationLongField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string mailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberResourcesDisabledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberResourcesMarkedInapprField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime registerDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
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
        public bool banned {
            get {
                return this.bannedField;
            }
            set {
                if ((this.bannedField.Equals(value) != true)) {
                    this.bannedField = value;
                    this.RaisePropertyChanged("banned");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fullName {
            get {
                return this.fullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.fullNameField, value) != true)) {
                    this.fullNameField = value;
                    this.RaisePropertyChanged("fullName");
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
        public string mail {
            get {
                return this.mailField;
            }
            set {
                if ((object.ReferenceEquals(this.mailField, value) != true)) {
                    this.mailField = value;
                    this.RaisePropertyChanged("mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numberResourcesDisabled {
            get {
                return this.numberResourcesDisabledField;
            }
            set {
                if ((this.numberResourcesDisabledField.Equals(value) != true)) {
                    this.numberResourcesDisabledField = value;
                    this.RaisePropertyChanged("numberResourcesDisabled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numberResourcesMarkedInappr {
            get {
                return this.numberResourcesMarkedInapprField;
            }
            set {
                if ((this.numberResourcesMarkedInapprField.Equals(value) != true)) {
                    this.numberResourcesMarkedInapprField = value;
                    this.RaisePropertyChanged("numberResourcesMarkedInappr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime registerDate {
            get {
                return this.registerDateField;
            }
            set {
                if ((this.registerDateField.Equals(value) != true)) {
                    this.registerDateField = value;
                    this.RaisePropertyChanged("registerDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTUser_Users", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTUser_Users : IndignadoWeb.UsersServiceReference.DTUser {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsersServiceReference.IUsersService")]
    public interface IUsersService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/getThemeCategoriesList", ReplyAction="http://tempuri.org/IUsersService/getThemeCategoriesListResponse")]
        IndignadoWeb.UsersServiceReference.DTThemeCategoriesColUsers getThemeCategoriesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/getInterestedThemeCategory", ReplyAction="http://tempuri.org/IUsersService/getInterestedThemeCategoryResponse")]
        void getInterestedThemeCategory(IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers dtThemeCategory);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/getUninterestedThemeCategory", ReplyAction="http://tempuri.org/IUsersService/getUninterestedThemeCategoryResponse")]
        void getUninterestedThemeCategory(IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers dtThemeCategory);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/getUser", ReplyAction="http://tempuri.org/IUsersService/getUserResponse")]
        IndignadoWeb.UsersServiceReference.DTUser_Users getUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/setUser", ReplyAction="http://tempuri.org/IUsersService/setUserResponse")]
        void setUser(IndignadoWeb.UsersServiceReference.DTUser_Users dtUser);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsersServiceChannel : IndignadoWeb.UsersServiceReference.IUsersService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsersServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.UsersServiceReference.IUsersService>, IndignadoWeb.UsersServiceReference.IUsersService {
        
        public UsersServiceClient() {
        }
        
        public UsersServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsersServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IndignadoWeb.UsersServiceReference.DTThemeCategoriesColUsers getThemeCategoriesList() {
            return base.Channel.getThemeCategoriesList();
        }
        
        public void getInterestedThemeCategory(IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers dtThemeCategory) {
            base.Channel.getInterestedThemeCategory(dtThemeCategory);
        }
        
        public void getUninterestedThemeCategory(IndignadoWeb.UsersServiceReference.DTThemeCategoryUsers dtThemeCategory) {
            base.Channel.getUninterestedThemeCategory(dtThemeCategory);
        }
        
        public IndignadoWeb.UsersServiceReference.DTUser_Users getUser() {
            return base.Channel.getUser();
        }
        
        public void setUser(IndignadoWeb.UsersServiceReference.DTUser_Users dtUser) {
            base.Channel.setUser(dtUser);
        }
    }
}
