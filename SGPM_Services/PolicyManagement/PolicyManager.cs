﻿using SGPM_Contracts.ILocalityManagement;
using SGPM_Contracts.IPolicyManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IPolicyManagement
    {
        public List<Policy> GetAllPolicies()
        {
            List<Policy> policyList = new List<Policy>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    var policyListDB = context.PoliticasOtorgamiento.ToList();
                    foreach (var policy in policyListDB)
                    {
                        Policy newPolicy = new Policy
                        {
                            PolicyID = policy.IdPoliticaOtorgamiento,
                            Name = policy.nombre,
                            Description = policy.descripcion
                        };

                        policyList.Add(newPolicy);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return policyList;
        }

        public int SavePolicy(Policy policy)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    PoliticasOtorgamiento politicaToBeSaved = new PoliticasOtorgamiento();
                    politicaToBeSaved.nombre = policy.Name;
                    politicaToBeSaved.descripcion = policy.Description;

                    context.PoliticasOtorgamiento.Add(politicaToBeSaved);
                    result = context.SaveChanges();
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }

        public int AddPolicyToProject(string folio, List<int> listPolicys)
        {
            int result = 0;
        public List<Policy> GetPolicies()
        {
            List<Policy> policyList = new List<Policy>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    DeletePolicyOfProject(folio);
                    foreach (var idPolicy in listPolicys)
                    {
                        ProyectoPoliticaOtorgamiento policy = new ProyectoPoliticaOtorgamiento
                        {
                            IdPoliticaOtorgamiento = idPolicy,
                            Folio = folio
                        };
                        context.ProyectoPoliticaOtorgamiento.Add(policy);
                    }
                    result = context.SaveChanges();
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result; 
        }

        public List<int> GetPolicysOfProject(string idProject)
        {
            List<int> listPolicy = new List<int>();
                    var policiesFromDatabase = context.PoliticasOtorgamiento.ToList();

                    if (policiesFromDatabase.Any())
                    {
                        foreach (var policy in policiesFromDatabase)
                        {
                            policyList.Add(new Policy
                            {
                                PolicyID = policy.IdPoliticaOtorgamiento,
                                Name = policy.nombre,
                                Description = policy.descripcion
                            });
                        }
                    }
                }
            }
            catch (Exception ex) when (ex is SqlException | ex is EntityException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return policyList;
        }

        public Policy GetPolicy(int policyId)
        {
            Policy policy = new Policy();

            try
            {
                using (var context = new SGPMEntities())
                {
                    var policyDB = context.ProyectoPoliticaOtorgamiento.Where(p => p.Folio == idProject).ToList();
                    if (policyDB != null)
                    {
                        foreach (var policy in policyDB)
                        {
                            listPolicy.Add((int)policy.IdPoliticaOtorgamiento);
                        }
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

            return listPolicy;
        }

        private void DeletePolicyOfProject(string idProject)
        {
                    var policyFromDB = context.PoliticasOtorgamiento.Where(politica => politica.IdPoliticaOtorgamiento == policyId).FirstOrDefault();

                    if (policyFromDB != null)
                    {
                        policy.Name = policyFromDB.nombre;
                        policy.Description = policyFromDB.descripcion;
                    }
                }
            }
            catch (Exception ex) when (ex is SqlException | ex is EntityException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

            return policy;
        }


        public int UpdatePolicy(Policy policy)
        {
            int result = 0;

            try
            {
                using (var context = new SGPMEntities())
                {
                    var policyFromDB = context.PoliticasOtorgamiento
                                              .Where(politica => politica.IdPoliticaOtorgamiento == policy.PolicyID)
                                              .SingleOrDefault();

                    if (policyFromDB != null)
                    {
                        policyFromDB.nombre = policy.Name;
                        policyFromDB.descripcion = policy.Description;

                        result = context.SaveChanges();
                    }
                }
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbEntityValidationException || ex is InvalidOperationException || ex is SqlException)
            {
                result = -1;
            }

            return result;
        }
    }
}
