﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.MeetingsServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTMeeting", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTMeeting : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idMovementField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imagePathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float locationLatiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float locationLongField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int minQuorumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int myAttendanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberAttendantsField;
        
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
        public string imagePath {
            get {
                return this.imagePathField;
            }
            set {
                if ((object.ReferenceEquals(this.imagePathField, value) != true)) {
                    this.imagePathField = value;
                    this.RaisePropertyChanged("imagePath");
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
        public int minQuorum {
            get {
                return this.minQuorumField;
            }
            set {
                if ((this.minQuorumField.Equals(value) != true)) {
                    this.minQuorumField = value;
                    this.RaisePropertyChanged("minQuorum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int myAttendance {
            get {
                return this.myAttendanceField;
            }
            set {
                if ((this.myAttendanceField.Equals(value) != true)) {
                    this.myAttendanceField = value;
                    this.RaisePropertyChanged("myAttendance");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numberAttendants {
            get {
                return this.numberAttendantsField;
            }
            set {
                if ((this.numberAttendantsField.Equals(value) != true)) {
                    this.numberAttendantsField = value;
                    this.RaisePropertyChanged("numberAttendants");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTMeetingsCol", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTMeetingsCol : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.MeetingsServiceReference.DTMeeting[] itemsField;
        
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
        public IndignadoWeb.MeetingsServiceReference.DTMeeting[] items {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MeetingsServiceReference.IMeetingsService")]
    public interface IMeetingsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeetingsService/getMeeting", ReplyAction="http://tempuri.org/IMeetingsService/getMeetingResponse")]
        IndignadoWeb.MeetingsServiceReference.DTMeeting getMeeting(int index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeetingsService/createMeeting", ReplyAction="http://tempuri.org/IMeetingsService/createMeetingResponse")]
        void createMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeetingsService/getMeetingsList", ReplyAction="http://tempuri.org/IMeetingsService/getMeetingsListResponse")]
        IndignadoWeb.MeetingsServiceReference.DTMeetingsCol getMeetingsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeetingsService/doAttendMeeting", ReplyAction="http://tempuri.org/IMeetingsService/doAttendMeetingResponse")]
        void doAttendMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeetingsService/unconfirmAttendMeeting", ReplyAction="http://tempuri.org/IMeetingsService/unconfirmAttendMeetingResponse")]
        void unconfirmAttendMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeetingsService/dontAttendMeeting", ReplyAction="http://tempuri.org/IMeetingsService/dontAttendMeetingResponse")]
        void dontAttendMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMeetingsServiceChannel : IndignadoWeb.MeetingsServiceReference.IMeetingsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MeetingsServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.MeetingsServiceReference.IMeetingsService>, IndignadoWeb.MeetingsServiceReference.IMeetingsService {
        
        public MeetingsServiceClient() {
        }
        
        public MeetingsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MeetingsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MeetingsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MeetingsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IndignadoWeb.MeetingsServiceReference.DTMeeting getMeeting(int index) {
            return base.Channel.getMeeting(index);
        }
        
        public void createMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting) {
            base.Channel.createMeeting(dtMeeting);
        }
        
        public IndignadoWeb.MeetingsServiceReference.DTMeetingsCol getMeetingsList() {
            return base.Channel.getMeetingsList();
        }
        
        public void doAttendMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting) {
            base.Channel.doAttendMeeting(dtMeeting);
        }
        
        public void unconfirmAttendMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting) {
            base.Channel.unconfirmAttendMeeting(dtMeeting);
        }
        
        public void dontAttendMeeting(IndignadoWeb.MeetingsServiceReference.DTMeeting dtMeeting) {
            base.Channel.dontAttendMeeting(dtMeeting);
        }
    }
}
