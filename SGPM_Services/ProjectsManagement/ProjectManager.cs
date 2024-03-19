using SGPM_Contracts.IProjectsManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.PerSession)]

    public partial class SGPMManager : IProjectsManagement
    {
        public Project GetProjectDetails(int idProject)
        {
            Project project = new Project();   

            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    ProyectoSet proyecto = context.ProyectoSet.FirstOrDefault(p => p.Folio == idProject);
                    project.Folio = proyecto.Folio;
                    project.Modality = proyecto.modalidad;
                    project.AttentionGroup = proyecto.grupoAtencion;
                    project.BeneficiaryNumbers = proyecto.numeroBeneficiarios;
                    return project;
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }



        

        
    }
}
