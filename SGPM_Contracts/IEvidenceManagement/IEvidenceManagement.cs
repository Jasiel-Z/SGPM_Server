using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Contracts.IEvidenceManagement
{
    [ServiceContract]
    public interface IEvidenceManagement
    {
        [OperationContract]
        List<ProjectShow> GetFinishProjectsd();
        [OperationContract]
        List<RequestShow> GetFinishRequestsd(string folio);
        [OperationContract]
        int SaveEvidence(Evidence evidence);
    }

    [DataContract]
    public class Evidence
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int IdRequest { get; set; }

        [DataMember]
        public byte[] file { get; set; }
    }

    [DataContract]
    public class ProjectShow
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Folio { get; set; }
    }

    [DataContract]
    public class RequestShow
    {
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
