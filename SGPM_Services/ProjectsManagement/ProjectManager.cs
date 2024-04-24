using SGPM_Contracts.IProjectsManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
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
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    var proyectos = context.Proyectos.ToList();
                    foreach (var proyecto in proyectos)
                    {
                    }
                    return projects;
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

        public List<Dependency> GetDependencies()
        {
            List<Dependency> dependenciesList = new List<Dependency>();

            return dependenciesList;
        }

        public List<Localidad> GetLocalidads()
        {
            List<Localidad> localidadList = new List<Localidad>();


            return localidadList;
        }

        public Project GetProjectDetails(int idProject)
        {
            Project project = new Project();   

            try
            {
                using (var context = new SGPMEntities())
                {
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

        public int RegisteredProjects(Project project)
        {
            int result = 1;
            if (project == null)
            {
                try
                {
                    using (var context = new SGPMEntities())
                    {
                    }
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (DbEntityValidationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (EntityException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return result;
        }
    }
}
