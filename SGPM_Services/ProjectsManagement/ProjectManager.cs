﻿using SGPM_Contracts.IProjectsManagement;
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
                    foreach (var dbProyect in proyectos)
                    {

                        Project sProject = new Project();
                        sProject.Folio = dbProyect.Folio;
                        sProject.Name = dbProyect.nombre;
                        sProject.Description = dbProyect.descripcion;
                        projects.Add(sProject);


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
            List<Dependency> dependenciesList = null;


            try
            {
                using (var context = new SGPMEntities())
                {
                    var dependecies = context.Dependencias.ToList();

                    foreach (var dependencyDB in dependecies)
                    {
                        Dependency dependency = new Dependency
                        {
                            IdDependency = dependencyDB.IdDependencia,
                            NameDependency = dependencyDB.nombre,
                        };
                        dependenciesList.Add(dependency);
                    }
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

            return dependenciesList;
        }

        public List<Localidad> GetLocalidads()
        {
            List<Localidad> localidadList = null;

            try
            {
                using (var context = new SGPMEntities())
                {
                    var localidads = context.Localidades.ToList();

                    foreach (var localidadDB in localidads)
                    {
                        Localidad dependency = new Localidad
                        {
                            IdLocalidad = localidadDB.IdLocalidad,
                            NameLocalidad = localidadDB.nombre,
                        };
                        localidadList.Add(dependency);
                    }
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

            return localidadList;
        }

        public Project GetProjectDetails(string idProject)
        {
            Project sProject = null;   

            try
            {
                using (var context = new SGPMEntities())
                {
                    
                    Proyectos dbProyect = context.Proyectos.FirstOrDefault(p => p.Folio == idProject);
                    if(dbProyect != null)
                    {
                        sProject = new Project();
                        sProject.Folio = dbProyect.Folio;
                        sProject.Name = dbProyect.nombre;
                        sProject.Description = dbProyect.descripcion;
                        sProject.Status = dbProyect.estado;
                        sProject.AttentionGroup = dbProyect.grupoAtencion;
                        sProject.Modality = dbProyect.modalidad;
                        sProject.Type = dbProyect.tipo;
                        sProject.SupportAmount = (double)dbProyect.montoApoyo;
                        sProject.BeneficiaryNumbers = (int)dbProyect.numeroBeneficiarios;
                        sProject.Start = (DateTime)dbProyect.fechaInicio;
                        sProject.Evidence = (DateTime)dbProyect.fechaLimiteEvidencias;
                        sProject.End = (DateTime)dbProyect.fechaFin;
                        sProject.Dependecy = dbProyect.Dependencias.IdDependencia;
                        sProject.Solicitud = (DateTime)dbProyect.fechaLimiteSolicitudes;
                        sProject.Location = (int)dbProyect.IdLocalidad;
                    }

                    
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

            return sProject;
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
                    projects = (from p in context.Proyectos
                                   where p.IdLocalidad == locationId  &&
                                   p.fechaLimiteSolicitudes >= System.DateTime.Today &&
                                   p.beneficiariosRestantes > 0
                                   select new Project
                                   {
                                        Folio = p.Folio,
                                        Modality = p.modalidad,
                                        AttentionGroup = p.grupoAtencion,
                                        Type = p.tipo,
                                        Name = p.nombre,
                                        Description = p.descripcion,
                                        SupportAmount = (double)p.montoApoyo,
                                        RemainingBeneficiaries = (int)p.beneficiariosRestantes
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

        public int RegisteredProjects(Project project)
        {
            int result = 0;
            if (project != null)
            {
                try
                {
                    using (var context = new SGPMEntities())
                    {
                        Proyectos proyectDB = new Proyectos
                        {
                            Folio = project.Folio,
                            nombre = project.Name,
                            descripcion = project.Description,
                            estado = project.Status,
                            grupoAtencion = project.AttentionGroup,
                            modalidad = project.Modality,
                            tipo = project.Type,
                            montoApoyo = project.SupportAmount,
                            numeroBeneficiarios = project.BeneficiaryNumbers,
                            fechaInicio = project.Start,
                            fechaLimiteSolicitudes = project.Solicitud,
                            fechaFin = project.End,
                            fechaLimiteEvidencias = project.Evidence,
                            IdDependencia = project.Dependecy,
                            IdLocalidad = project.Location,
                            beneficiariosRestantes = project.BeneficiaryNumbers

                        };
                        if(proyectDB.IdLocalidad > 0)
                        {
                            context.Proyectos.AddOrUpdate(proyectDB);
                            result = context.SaveChanges();
                        }
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

        public int updateRemainingBeneficiaries(string folio)
        {
            int result = -1;

            try
            {
                using (var context = new SGPMEntities())
                {
                    var project = context.Proyectos.FirstOrDefault(p => p.Folio == folio);
                
                    if(project != null && project.beneficiariosRestantes > 0)
                    {
                        project.beneficiariosRestantes--;

                        result = context.SaveChanges();

                    }

                    return result;
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                return result;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                return result;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                return result;

            }
        }
    }
}
