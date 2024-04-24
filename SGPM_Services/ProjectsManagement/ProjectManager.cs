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
        public Project GetProjectDetails(string idProject)
        {
            Project sProject = new Project();   

            try
            {
                using (var context = new SGPMEntities())
                {
                    Proyectos dbProyect = context.Proyectos.FirstOrDefault(p => p.Folio == idProject);
                    sProject.Folio = dbProyect.Folio;
                    sProject.Modality = dbProyect.modalidad;
                    sProject.AttentionGroup = dbProyect.grupoAtencion;
                    sProject.BeneficiaryNumbers = (int)dbProyect.numeroBeneficiarios;
                    sProject.Type = dbProyect.tipo;
                    sProject.Name = dbProyect.nombre;
                    sProject.Description = dbProyect.descripcion;

                    return sProject;
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

        public List<ProjectPolicy> GetProjectPolicies(string idProject)
        {
            List<ProjectPolicy> policies = new List<ProjectPolicy>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    policies = (from pp in context.ProyectoPoliticaOtorgamiento
                                where pp.Folio.Equals(idProject)
                                select new ProjectPolicy
                                {
                                    Id = pp.IdProyectoPoliticaOtorgamiento,
                                    ProyectFolio = pp.Folio,
                                    GrantingPolicy = pp.IdPoliticaOtorgamiento.Value,
                                    Name = pp.PoliticasOtorgamiento.nombre,
                                    Description = pp.PoliticasOtorgamiento.descripcion
                                }).ToList();
                }
                return policies;
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

        public List<Project> GetProjectsFromLocality(int locationId)
        {
            List<Project> projects = new List<Project>();
            try
            {

                using (var context = new SGPMEntities())
                {
                    projects = (from ld in context.DependenciaLocalidad
                                   join p in context.Proyectos
                                   on ld.IdDependencia equals p.IdDependencia
                                   where ld.IdLocalidad == locationId
                                   select new Project
                                   {
                                        Folio = p.Folio,
                                        Modality = p.modalidad,
                                        AttentionGroup = p.grupoAtencion,
                                        Type = p.tipo,
                                        Name = p.nombre,
                                        Description = p.descripcion,
                                   }).ToList();
                    }

                return projects;

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
