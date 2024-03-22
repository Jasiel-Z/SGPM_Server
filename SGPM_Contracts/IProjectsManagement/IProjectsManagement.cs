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
        Project GetProjectDetails(int idProject);


        [OperationContract]
        List<ProjectPolicy> GetProjectPolicies(int idProject);


        [OperationContract]
        List<Project> GetProjectsFromLocality(int locationId);


    }

    [DataContract]
    public class Project
    {
        [DataMember]
        public int Folio {  get; set; }

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
        public int  ProyectFolio { get; set; }
        [DataMember]
        public int GrantingPolicy { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Name { get; set; }
    }


}
