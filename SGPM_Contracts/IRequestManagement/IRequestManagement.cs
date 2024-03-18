using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Linq;
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
        int RegisterRequest(Solicitud request);

        [OperationContract]
        int RegisterRequestDocumentation(List<Archivo> files);


        //methods needed for the use case no.12
        [OperationContract]
        Solicitud RecoverRequestDetails(int idRequest);

    }
}

