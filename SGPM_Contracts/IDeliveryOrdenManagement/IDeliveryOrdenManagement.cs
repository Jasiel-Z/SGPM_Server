using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Contracts.IDeliveryOrdenManagement
{
    [ServiceContract]
    public interface IDeliveryOrdenManagement
    {
        [OperationContract]
        int SaveDeliveryOrden(DeliveryOrden deliveryOrden, string folio);

        [OperationContract]
        DeliveryOrden GetDeliveryOrden(string folio);

        [OperationContract]
        Collection<Resource> GetResources();

    }

    [DataContract]
    public class DeliveryOrden
    {
        [DataMember]
        public int IdDeliveryOrden { get; set; }
        
        [DataMember]
        public string DeliveryPlace { get; set; }
        
        [DataMember]
        public DateTime DeliveryDate { get; set; }
        
        [DataMember]
        public string Amount { get; set; }

        [DataMember]
        public Resource Resource {  get; set; } 

    }

    [DataContract]
    public class Resource
    {
        [DataMember]
        public int IdResource { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
