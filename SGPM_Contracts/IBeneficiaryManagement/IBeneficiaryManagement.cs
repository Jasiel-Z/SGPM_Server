using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Contracts.IBeneficiaryManagement
{
    [ServiceContract]
    public interface IBeneficiaryManagement
    {
        [OperationContract]
        List<Beneficiary> GetBeneficiaries();

        [OperationContract]
        List<Person> GetPersons(string name);

        [OperationContract]
        List<Company> GetCompanies(string name);

    }



    [DataContract]
    public class Beneficiary
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string RFC { get; set; }
        [DataMember]
        public int LocalityId { get; set; }


    }


    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string  CURP { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public int BeneficiaryId { get; set; }
 
    }


    [DataContract]
    public class Company
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public int BeneficiaryId { get; set; }
    }
}
