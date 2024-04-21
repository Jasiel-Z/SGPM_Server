using SGPM_DataBAse;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SGPM_Contracts.ILocalityManagement
{
    [ServiceContract]
    public interface ILocalityManagement
    {
        [OperationContract]
        int SaveLocality(Locality locality);

        [OperationContract]
        bool ValidateLocalityDoesNotExist(string localityName);
        
        [OperationContract]
        List<Locality> GetLocalities();
    }

    [DataContract]
    public class Locality
    {

        [DataMember]
        public int LocalityID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Township {  get; set; }
    }
}
