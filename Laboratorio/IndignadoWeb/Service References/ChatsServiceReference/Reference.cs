﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.530
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoWeb.ChatsServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTChatRoom", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTChatRoom : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTChatMessage", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTChatMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int fromIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string messageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IndignadoWeb.ChatsServiceReference.DTChatRoom roomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int typeField;
        
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
        public string from {
            get {
                return this.fromField;
            }
            set {
                if ((object.ReferenceEquals(this.fromField, value) != true)) {
                    this.fromField = value;
                    this.RaisePropertyChanged("from");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int fromId {
            get {
                return this.fromIdField;
            }
            set {
                if ((this.fromIdField.Equals(value) != true)) {
                    this.fromIdField = value;
                    this.RaisePropertyChanged("fromId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message {
            get {
                return this.messageField;
            }
            set {
                if ((object.ReferenceEquals(this.messageField, value) != true)) {
                    this.messageField = value;
                    this.RaisePropertyChanged("message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public IndignadoWeb.ChatsServiceReference.DTChatRoom room {
            get {
                return this.roomField;
            }
            set {
                if ((object.ReferenceEquals(this.roomField, value) != true)) {
                    this.roomField = value;
                    this.RaisePropertyChanged("room");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int type {
            get {
                return this.typeField;
            }
            set {
                if ((this.typeField.Equals(value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DTChatUser", Namespace="http://schemas.datacontract.org/2004/07/IndignadoServer.Services")]
    [System.SerializableAttribute()]
    public partial class DTChatUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool activeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nickField;
        
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
        public bool active {
            get {
                return this.activeField;
            }
            set {
                if ((this.activeField.Equals(value) != true)) {
                    this.activeField = value;
                    this.RaisePropertyChanged("active");
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
        public string nick {
            get {
                return this.nickField;
            }
            set {
                if ((object.ReferenceEquals(this.nickField, value) != true)) {
                    this.nickField = value;
                    this.RaisePropertyChanged("nick");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatsServiceReference.IChatsService")]
    public interface IChatsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/initChatWith", ReplyAction="http://tempuri.org/IChatsService/initChatWithResponse")]
        IndignadoWeb.ChatsServiceReference.DTChatRoom initChatWith(int user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/closeChat", ReplyAction="http://tempuri.org/IChatsService/closeChatResponse")]
        void closeChat(int room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/sendMesage", ReplyAction="http://tempuri.org/IChatsService/sendMesageResponse")]
        void sendMesage(int type, int room, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/checkMessages", ReplyAction="http://tempuri.org/IChatsService/checkMessagesResponse")]
        System.Collections.Generic.List<IndignadoWeb.ChatsServiceReference.DTChatMessage> checkMessages(bool onlyUnConsumed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/HeartBeat", ReplyAction="http://tempuri.org/IChatsService/HeartBeatResponse")]
        void HeartBeat();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/GetUsersOnline", ReplyAction="http://tempuri.org/IChatsService/GetUsersOnlineResponse")]
        System.Collections.Generic.List<IndignadoWeb.ChatsServiceReference.DTChatUser> GetUsersOnline(bool onlyUnConsumed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatsService/GetUsersOnlineCount", ReplyAction="http://tempuri.org/IChatsService/GetUsersOnlineCountResponse")]
        int GetUsersOnlineCount();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatsServiceChannel : IndignadoWeb.ChatsServiceReference.IChatsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatsServiceClient : System.ServiceModel.ClientBase<IndignadoWeb.ChatsServiceReference.IChatsService>, IndignadoWeb.ChatsServiceReference.IChatsService {
        
        public ChatsServiceClient() {
        }
        
        public ChatsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IndignadoWeb.ChatsServiceReference.DTChatRoom initChatWith(int user) {
            return base.Channel.initChatWith(user);
        }
        
        public void closeChat(int room) {
            base.Channel.closeChat(room);
        }
        
        public void sendMesage(int type, int room, string message) {
            base.Channel.sendMesage(type, room, message);
        }
        
        public System.Collections.Generic.List<IndignadoWeb.ChatsServiceReference.DTChatMessage> checkMessages(bool onlyUnConsumed) {
            return base.Channel.checkMessages(onlyUnConsumed);
        }
        
        public void HeartBeat() {
            base.Channel.HeartBeat();
        }
        
        public System.Collections.Generic.List<IndignadoWeb.ChatsServiceReference.DTChatUser> GetUsersOnline(bool onlyUnConsumed) {
            return base.Channel.GetUsersOnline(onlyUnConsumed);
        }
        
        public int GetUsersOnlineCount() {
            return base.Channel.GetUsersOnlineCount();
        }
    }
}
