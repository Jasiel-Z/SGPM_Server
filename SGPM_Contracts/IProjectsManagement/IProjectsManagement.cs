using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SGPM_DataBAse;

namespace SGPM_Contracts.IProjectsManagement
{
    [ServiceContract]
    public interface IProjectsManagement
    {
        [OperationContract]
        Project GetProjectDetails(string idProject);


        [OperationContract]
        List<ProjectPolicy> GetProjectPolicies(string idProject);


        [OperationContract]
        List<Project> GetProjectsFromLocality(int locationId);


    }

    [DataContract]
    public class Project
    {
        [DataMember]
        public string Folio {  get; set; }

        [DataMember]
        public string  Modality { get; set; }

        [DataMember]
        public string AttentionGroup { get; set; }

        [DataMember]
        public int BeneficiaryNumbers { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class ProjectPolicy{
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string  ProyectFolio { get; set; }
        [DataMember]
        public int GrantingPolicy { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Name { get; set; }
    }


}
