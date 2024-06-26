﻿using SGPM_DataBAse;
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
        [OperationContract]
         Request RecoverRequestDetails(int requestId);
        [OperationContract]
        int RegisterRequestWithDocuments(SolicitudSet request, List<SGPM_Contracts.IRequestManagement.File> files);

        [OperationContract]
        bool BeneficiaryHasRequest(int beneficiaryId, int projectFolio);

        [OperationContract]
        List<File> GetRequestFiles(int requestId);
        [OperationContract]
        int RegisterOpinion(Opinion opinion, int requestId);

        [OperationContract]
        List<Request> GetRequestsOfProject(int projectId);


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

    [DataContract]
    public class Request
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public System.DateTime CreationTime { get; set; }
        [DataMember]
        public int ProyectFolio { get; set; }

        [DataMember]
        public int BeneficiaryId { get; set;}

    }

    [DataContract]
    public class Opinion {

        [DataMember]
        public int OpinionId { get; set; }
        [DataMember]

        public string State { get; set; }
        [DataMember]

        public string Comment { get; set; }
        [DataMember]

        public System.DateTime Date { get; set; }
        [DataMember]

        public int EmployeeNumber { get; set; }
    }
}

