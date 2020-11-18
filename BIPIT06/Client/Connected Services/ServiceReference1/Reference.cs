﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Shippings", Namespace="http://schemas.datacontract.org/2004/07/BIPIT05")]
    [System.SerializableAttribute()]
    public partial class Shippings : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string shipping_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string client_fullnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string service_titleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string service_costField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string shipping_dateField;
        
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
        public string shipping_id {
            get {
                return this.shipping_idField;
            }
            set {
                if ((object.ReferenceEquals(this.shipping_idField, value) != true)) {
                    this.shipping_idField = value;
                    this.RaisePropertyChanged("shipping_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string client_fullname {
            get {
                return this.client_fullnameField;
            }
            set {
                if ((object.ReferenceEquals(this.client_fullnameField, value) != true)) {
                    this.client_fullnameField = value;
                    this.RaisePropertyChanged("client_fullname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string service_title {
            get {
                return this.service_titleField;
            }
            set {
                if ((object.ReferenceEquals(this.service_titleField, value) != true)) {
                    this.service_titleField = value;
                    this.RaisePropertyChanged("service_title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string service_cost {
            get {
                return this.service_costField;
            }
            set {
                if ((object.ReferenceEquals(this.service_costField, value) != true)) {
                    this.service_costField = value;
                    this.RaisePropertyChanged("service_cost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string shipping_date {
            get {
                return this.shipping_dateField;
            }
            set {
                if ((object.ReferenceEquals(this.shipping_dateField, value) != true)) {
                    this.shipping_dateField = value;
                    this.RaisePropertyChanged("shipping_date");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        Client.ServiceReference1.Shippings[] GetData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.Shippings[]> GetDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetClients", ReplyAction="http://tempuri.org/IService/GetClientsResponse")]
        System.Collections.Generic.Dictionary<int, string> GetClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetClients", ReplyAction="http://tempuri.org/IService/GetClientsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, string>> GetClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetServices", ReplyAction="http://tempuri.org/IService/GetServicesResponse")]
        System.Collections.Generic.Dictionary<int, string> GetServices();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetServices", ReplyAction="http://tempuri.org/IService/GetServicesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, string>> GetServicesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/NewRec", ReplyAction="http://tempuri.org/IService/NewRecResponse")]
        void NewRec(int client_id, int service_id, System.DateTime shipping_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/NewRec", ReplyAction="http://tempuri.org/IService/NewRecResponse")]
        System.Threading.Tasks.Task NewRecAsync(int client_id, int service_id, System.DateTime shipping_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/isHostAlive", ReplyAction="http://tempuri.org/IService/isHostAliveResponse")]
        bool isHostAlive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/isHostAlive", ReplyAction="http://tempuri.org/IService/isHostAliveResponse")]
        System.Threading.Tasks.Task<bool> isHostAliveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStatus", ReplyAction="http://tempuri.org/IService/GetStatusResponse")]
        void GetStatus(string name, string port, string loaclPath, string uri, string scheme);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStatus", ReplyAction="http://tempuri.org/IService/GetStatusResponse")]
        System.Threading.Tasks.Task GetStatusAsync(string name, string port, string loaclPath, string uri, string scheme);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IService>, Client.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.ServiceReference1.Shippings[] GetData() {
            return base.Channel.GetData();
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.Shippings[]> GetDataAsync() {
            return base.Channel.GetDataAsync();
        }
        
        public System.Collections.Generic.Dictionary<int, string> GetClients() {
            return base.Channel.GetClients();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, string>> GetClientsAsync() {
            return base.Channel.GetClientsAsync();
        }
        
        public System.Collections.Generic.Dictionary<int, string> GetServices() {
            return base.Channel.GetServices();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, string>> GetServicesAsync() {
            return base.Channel.GetServicesAsync();
        }
        
        public void NewRec(int client_id, int service_id, System.DateTime shipping_date) {
            base.Channel.NewRec(client_id, service_id, shipping_date);
        }
        
        public System.Threading.Tasks.Task NewRecAsync(int client_id, int service_id, System.DateTime shipping_date) {
            return base.Channel.NewRecAsync(client_id, service_id, shipping_date);
        }
        
        public bool isHostAlive() {
            return base.Channel.isHostAlive();
        }
        
        public System.Threading.Tasks.Task<bool> isHostAliveAsync() {
            return base.Channel.isHostAliveAsync();
        }
        
        public void GetStatus(string name, string port, string loaclPath, string uri, string scheme) {
            base.Channel.GetStatus(name, port, loaclPath, uri, scheme);
        }
        
        public System.Threading.Tasks.Task GetStatusAsync(string name, string port, string loaclPath, string uri, string scheme) {
            return base.Channel.GetStatusAsync(name, port, loaclPath, uri, scheme);
        }
    }
}
