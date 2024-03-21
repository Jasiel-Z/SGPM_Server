using System;
using System.Collections.Generic;
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
        int RegisteredProjects(Project project);

        [OperationContract]
        List<Project> GetAllProjects();

        [OperationContract]
        List<Localidad> GetLocalidads();

        [OperationContract]
        List<Dependency> GetDependencies();
    }

    [DataContract]
    public class Project
    {
        [DataMember]
        public int Folio {  get; set; }

        [DataMember] 
        public string Name { get; set; }

        [DataMember] 
        public string Description { get; set; }

        [DataMember] 
        public int SupportAmount{ get; set; }
        
        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Dependecy { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Modality { get; set; }

        [DataMember]
        public string AttentionGroup { get; set; }

        [DataMember]
        public int BeneficiaryNumbers { get; set; }

        [DataMember]
        public DateTime Start {  get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public DateTime Evidence { get; set; }
    }

    [DataContract]
    public class Localidad
    {
        [DataMember]
        public int IdLocalidad { get; set; }

        [DataMember]
        public string NameLocalidad { get; set;  }
    }

    [DataContract]
    public class Dependency
    {
        [DataMember]
        public int IdDependency { get; set; }

        [DataMember]
        public string NameDependency { get; set; }
    }
}
