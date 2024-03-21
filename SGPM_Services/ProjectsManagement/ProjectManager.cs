﻿using SGPM_Contracts.IProjectsManagement;
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
            Project sProject = new Project();   

            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    ProyectoSet dbProyect = context.ProyectoSet.FirstOrDefault(p => p.Folio == idProject);
                    sProject.Folio = dbProyect.Folio;
                    sProject.Modality = dbProyect.modalidad;
                    sProject.AttentionGroup = dbProyect.grupoAtencion;
                    sProject.BeneficiaryNumbers = dbProyect.numeroBeneficiarios;
                    sProject.Type = dbProyect.tipo;
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

        public List<ProjectPolicy> GetProjectPolicies(int idProject)
        {
            List<ProjectPolicy> policies = new List<ProjectPolicy>();

            try
            {

                using (var context = new DataBaseModelContainer())
                {
                    policies = (from pp in context.PoliticaProyectoSet
                                where pp.ProyectoFolio == idProject
                                select new ProjectPolicy
                                {
                                    Id = pp.IdPoliticaProyecto,
                                    ProyectFolio = pp.ProyectoFolio.Value,
                                    GrantingPolicy = pp.PoliticaOtorgamientoIdPolitica.Value,
                                    Name = pp.PoliticaOtorgamientoSet.nombre,
                                    Description = pp.PoliticaOtorgamientoSet.descripcion
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

    }
}
