using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Contracts.IRequestManagement

{
    [ServiceContract]
    public interface IRequestManagement
    {
        // methods needed for the use case no.11

        [OperationContract]
        int RegisterRequest(SolicitudSet request);

        [OperationContract]
        int RegisterRequestDocumentation(List<File> files);

        //methods needed for the use case no.12
        [OperationContract]
        SolicitudSet RecoverRequestDetails(int requestId);



    }

    [DataContract]
    public class File
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public byte[] Content { get; set; }

        [DataMember]
        public int RequestId { get; set; }
    }
}

