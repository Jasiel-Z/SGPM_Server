using System;
using System.Collections.Generic;
using System.Linq;
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
        Proyecto GetProjectDetails(int idProject);


    }
}
