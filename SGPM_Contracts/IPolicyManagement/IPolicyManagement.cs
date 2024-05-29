﻿using SGPM_DataBAse;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SGPM_Contracts.IPolicyManagement
{
    [ServiceContract]
    public interface IPolicyManagement
    {
        [OperationContract]
        int SavePolicy(Policy policy);

        [OperationContract]
        List<Policy> GetAllPolicies();

        [OperationContract]
        int AddPolicyToProject(string idProject, List<int> listPolicys);

        [OperationContract]
        List<int> GetPolicysOfProject(string idProject);
    }

    [DataContract]
    public class Policy
    {
        [DataMember]
        public int PolicyID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
