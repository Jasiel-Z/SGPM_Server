﻿using System;
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
        int RegisteredProjects(Project project);

        [OperationContract]
        List<ProjectPolicy> GetProjectPolicies(string idProject);

        [OperationContract]
        List<Project> GetAllProjects();

        [OperationContract]
        List<Localidad> GetLocalidads();

        [OperationContract]
        List<Dependency> GetDependencies();

        [OperationContract]
        List<Project> GetProjectsFromLocality(int locationId);

        [OperationContract]
        int updateRemainingBeneficiaries(string folio);
    }

    [DataContract]
    public class Project
    {
        [DataMember]
        public string Folio {  get; set; }

        [DataMember] 
        public string Name { get; set; }

        [DataMember] 
        public string Description { get; set; }

        [DataMember] 
        public double SupportAmount{ get; set; }
        
        [DataMember]
        public int Location { get; set; }

        [DataMember]
        public int Dependecy { get; set; }

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
        public string Type { get; set; }

        [DataMember]
        public DateTime Start {  get; set; }

        [DataMember]
        public DateTime Solicitud { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public DateTime Evidence { get; set; }

        [DataMember]
        public int RemainingBeneficiaries {  get; set; }
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
