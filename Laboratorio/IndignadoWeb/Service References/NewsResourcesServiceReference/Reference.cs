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
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sourceTitleField;
        
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
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
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
        public string image {
            get {
                return this.imageField;
            }
            set {
                if ((object.ReferenceEquals(this.imageField, value) != true)) {
                    this.imageField = value;
                    this.RaisePropertyChanged("image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string sourceTitle {
            get {
                return this.sourceTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.sourceTitleField, value) != true)) {
                    this.sourceTitleField = value;
                    this.RaisePropertyChanged("sourceTitle");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTResourcesCol_NewsResources", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTResourcesCol_NewsResources : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources[] itemsField;
        
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
        public IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources[] items {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTResource_NewsResources", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTResource_NewsResources : IndignadoWeb.NewsResourcesServiceReference.DTResource {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTResource", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources))]
    public partial class DTResource : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int disabledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int iLikeItField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int myMarkInapprField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberLikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberMarksInapprField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string titleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string urlImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string urlLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string urlThumbField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string urlVideoField;
        
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
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
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
        public int disabled {
            get {
                return this.disabledField;
            }
            set {
                if ((this.disabledField.Equals(value) != true)) {
                    this.disabledField = value;
                    this.RaisePropertyChanged("disabled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int iLikeIt {
            get {
                return this.iLikeItField;
            }
            set {
                if ((this.iLikeItField.Equals(value) != true)) {
                    this.iLikeItField = value;
                    this.RaisePropertyChanged("iLikeIt");
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
        public int idUser {
            get {
                return this.idUserField;
            }
            set {
                if ((this.idUserField.Equals(value) != true)) {
                    this.idUserField = value;
                    this.RaisePropertyChanged("idUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int myMarkInappr {
            get {
                return this.myMarkInapprField;
            }
            set {
                if ((this.myMarkInapprField.Equals(value) != true)) {
                    this.myMarkInapprField = value;
                    this.RaisePropertyChanged("myMarkInappr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numberLikes {
            get {
                return this.numberLikesField;
            }
            set {
                if ((this.numberLikesField.Equals(value) != true)) {
                    this.numberLikesField = value;
                    this.RaisePropertyChanged("numberLikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numberMarksInappr {
            get {
                return this.numberMarksInapprField;
            }
            set {
                if ((this.numberMarksInapprField.Equals(value) != true)) {
                    this.numberMarksInapprField = value;
                    this.RaisePropertyChanged("numberMarksInappr");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string urlImage {
            get {
                return this.urlImageField;
            }
            set {
                if ((object.ReferenceEquals(this.urlImageField, value) != true)) {
                    this.urlImageField = value;
                    this.RaisePropertyChanged("urlImage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string urlLink {
            get {
                return this.urlLinkField;
            }
            set {
                if ((object.ReferenceEquals(this.urlLinkField, value) != true)) {
                    this.urlLinkField = value;
                    this.RaisePropertyChanged("urlLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string urlThumb {
            get {
                return this.urlThumbField;
            }
            set {
                if ((object.ReferenceEquals(this.urlThumbField, value) != true)) {
                    this.urlThumbField = value;
                    this.RaisePropertyChanged("urlThumb");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string urlVideo {
            get {
                return this.urlVideoField;
            }
            set {
                if ((object.ReferenceEquals(this.urlVideoField, value) != true)) {
                    this.urlVideoField = value;
                    this.RaisePropertyChanged("urlVideo");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTUser", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(IndignadoWeb.NewsResourcesServiceReference.DTUser_NewsResources))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTUser_NewsResources", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTUser_NewsResources : IndignadoWeb.NewsResourcesServiceReference.DTUser {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTUserDetails_NewsResources", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTUserDetails_NewsResources : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources[] resourcesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.NewsResourcesServiceReference.DTUser_NewsResources userField;
        
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
        public IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources[] resources {
            get {
                return this.resourcesField;
            }
            set {
                if ((object.ReferenceEquals(this.resourcesField, value) != true)) {
                    this.resourcesField = value;
                    this.RaisePropertyChanged("resources");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public IndignadoWeb.NewsResourcesServiceReference.DTUser_NewsResources user {
            get {
                return this.userField;
            }
            set {
                if ((object.ReferenceEquals(this.userField, value) != true)) {
                    this.userField = value;
                    this.RaisePropertyChanged("user");
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/getNewsList", ReplyAction="http://tempuri.org/INewsResourcesService/getNewsListResponse")]
        IndignadoWeb.NewsResourcesServiceReference.DTRssItemsCol getNewsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/getResourcesList", ReplyAction="http://tempuri.org/INewsResourcesService/getResourcesListResponse")]
        IndignadoWeb.NewsResourcesServiceReference.DTResourcesCol_NewsResources getResourcesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/getResourcesListTopRanked", ReplyAction="http://tempuri.org/INewsResourcesService/getResourcesListTopRankedResponse")]
        IndignadoWeb.NewsResourcesServiceReference.DTResourcesCol_NewsResources getResourcesListTopRanked();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/getUserDetails", ReplyAction="http://tempuri.org/INewsResourcesService/getUserDetailsResponse")]
        IndignadoWeb.NewsResourcesServiceReference.DTUserDetails_NewsResources getUserDetails(IndignadoWeb.NewsResourcesServiceReference.DTUser_NewsResources dtUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/createResource", ReplyAction="http://tempuri.org/INewsResourcesService/createResourceResponse")]
        void createResource(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources dtResource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/getResourceData", ReplyAction="http://tempuri.org/INewsResourcesService/getResourceDataResponse")]
        IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources getResourceData(string link);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/likeResource", ReplyAction="http://tempuri.org/INewsResourcesService/likeResourceResponse")]
        void likeResource(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources dtResource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/unlikeResource", ReplyAction="http://tempuri.org/INewsResourcesService/unlikeResourceResponse")]
        void unlikeResource(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources dtResource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/markResourceInappropriate", ReplyAction="http://tempuri.org/INewsResourcesService/markResourceInappropriateResponse")]
        void markResourceInappropriate(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources resource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsResourcesService/unmarkResourceInappropriate", ReplyAction="http://tempuri.org/INewsResourcesService/unmarkResourceInappropriateResponse")]
        void unmarkResourceInappropriate(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources resource);
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
        
        public IndignadoWeb.NewsResourcesServiceReference.DTRssItemsCol getNewsList() {
            return base.Channel.getNewsList();
        }
        
        public IndignadoWeb.NewsResourcesServiceReference.DTResourcesCol_NewsResources getResourcesList() {
            return base.Channel.getResourcesList();
        }
        
        public IndignadoWeb.NewsResourcesServiceReference.DTResourcesCol_NewsResources getResourcesListTopRanked() {
            return base.Channel.getResourcesListTopRanked();
        }
        
        public IndignadoWeb.NewsResourcesServiceReference.DTUserDetails_NewsResources getUserDetails(IndignadoWeb.NewsResourcesServiceReference.DTUser_NewsResources dtUser) {
            return base.Channel.getUserDetails(dtUser);
        }
        
        public void createResource(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources dtResource) {
            base.Channel.createResource(dtResource);
        }
        
        public IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources getResourceData(string link) {
            return base.Channel.getResourceData(link);
        }
        
        public void likeResource(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources dtResource) {
            base.Channel.likeResource(dtResource);
        }
        
        public void unlikeResource(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources dtResource) {
            base.Channel.unlikeResource(dtResource);
        }
        
        public void markResourceInappropriate(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources resource) {
            base.Channel.markResourceInappropriate(resource);
        }
        
        public void unmarkResourceInappropriate(IndignadoWeb.NewsResourcesServiceReference.DTResource_NewsResources resource) {
            base.Channel.unmarkResourceInappropriate(resource);
        }
    }
}
