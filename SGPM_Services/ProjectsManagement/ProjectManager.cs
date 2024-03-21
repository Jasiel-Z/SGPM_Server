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
                using (var context = new DataBaseModelContainer())
                {
                    var proyectos = context.ProyectoSet.ToList();
                    foreach (var proyecto in proyectos)
                    {
                        Project project = new Project
                        {
                            Folio = proyecto.Folio,
                            Modality = proyecto.modalidad,
                            AttentionGroup = proyecto.grupoAtencion,
                            BeneficiaryNumbers = proyecto.numeroBeneficiarios
                        };
                        projects.Add(project);
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
            List<DependenciaSet> dependencies = new List<DependenciaSet>(); 
            List<Dependency> dependenciesList = new List<Dependency>();

            using(var context = new DataBaseModelContainer())
            {
                dependencies = context.DependenciaSet.ToList();
                foreach(var dep in dependencies)
                {
                    Dependency dependency = new Dependency();
                    dependency.IdDependency = dep.IdDependencia;
                    dependency.NameDependency = dep.nombre;
                    dependenciesList.Add(dependency);
                }
            }

            return dependenciesList;
        }

        public List<Localidad> GetLocalidads()
        {
            List<LocalidadSet> localidads = new List<LocalidadSet>();
            List<Localidad> localidadList = new List<Localidad>();

            using (var context = new DataBaseModelContainer())
            {
                localidads = context.LocalidadSet.ToList();
                foreach (var loc in localidads)
                {
                    Localidad dependency = new Localidad();
                    dependency.IdLocalidad = loc.IdLocalidad;
                    dependency.NameLocalidad = loc.nombre;
                    localidadList.Add(dependency);
                }
            }

            return localidadList;
        }

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

        public int RegisteredProjects(Project project)
        {
            int result = 1;
            if (project == null)
            {
                try
                {
                    using (var context = new DataBaseModelContainer())
                    {
                        ProyectoSet proyecto = new ProyectoSet();
                        proyecto.Folio = project.Folio;
                        proyecto.grupoAtencion = project.AttentionGroup;
                        proyecto.estado = project.Status;
                        proyecto.tipo = project.Modality;
                        proyecto.fechaFin = project.End;
                        proyecto.fechaLimiteEvidencia = project.Evidence;
                        proyecto.fechaLimiteSolicitud = project.Start;

                        context.ProyectoSet.AddOrUpdate(proyecto);
                        context.SaveChanges();
                        result = 0;
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
