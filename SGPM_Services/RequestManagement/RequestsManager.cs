using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SGPM_Contracts.IBeneficiaryManagement;
using SGPM_Contracts.IRequestManagement;
using SGPM_DataBAse;


namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IRequestManagement
    {
        public Request RecoverRequestDetails(int idRequest)
        {
            Request request = new Request();
            try
            {
                using (var context = new SGPMEntities())
                {
                    request = (from req in context.Solicitudes
                                 where req.IdSolicitud == idRequest
                                 select new Request
                                 {
                                     Id = req.IdSolicitud,
                                     CreationTime = (DateTime)req.fechaCreacion,
                                     BeneficiaryId = (int)req.IdBeneficiario,
                                    
                                 }).FirstOrDefault();
                }


            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                request = null;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                request = null;
            }
            catch (System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                request = null;
            }


            return request;
        }

        public int RegisterRequest(Solicitudes request)
        {
            int result = 0;
            try
            {
                using(var context = new SGPMEntities())
                {
                    context.Solicitudes.Add(request);
                    result = context.SaveChanges();
                }
            }catch(SqlException exception) {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);  
                result = -1;
            }
            catch(System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }

        public int RegisterRequestDocumentation(List<SGPM_Contracts.IRequestManagement.File> files)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    foreach (var file in files)
                    {

                        Documentos archivoSet = new Documentos()
                        {
                            nombre = file.Name,
                            direccion = file.Description,
                            IdSolicitud = 1
                        };
                        context.Documentos.Add(archivoSet);
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
            catch (System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }



        public int RegisterRequestWithDocuments(Solicitudes request, List<SGPM_Contracts.IRequestManagement.File> files)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    context.Solicitudes.Add(request);
                    context.SaveChanges();

                    int solicitudId = request.IdSolicitud;

                    foreach (var file in files)
                    {
                        Documentos archivoSet = new Documentos()
                        {
                            nombre = file.Name,
                            direccion = file.Description,
                            IdSolicitud = solicitudId
                            
                        };
                        context.Documentos.Add(archivoSet);
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
            catch (System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }


        public bool BeneficiaryHasRequest(int beneficiaryId, string projectFolio)
        {
            bool result = false;
            using (var context = new SGPMEntities
                ())
            {
            result = context.Solicitudes.Any(s => s.IdBeneficiario == beneficiaryId && s.Folio == projectFolio);
            }

            return result;
        }


        public List<SGPM_Contracts.IRequestManagement.File> GetRequestFiles(int requestId)
        {
            List<SGPM_Contracts.IRequestManagement.File> files = new List<SGPM_Contracts.IRequestManagement.File>();
            try
            {
                using (var context = new SGPMEntities())
                {
                    files = (from file in context.Documentos
                             where file.IdSolicitud == requestId
                             select new SGPM_Contracts.IRequestManagement.File
                             {
                                 Name = file.nombre,
                                 Description = file.direccion,
                             }).ToList();

                }
                return files;
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
            catch (System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }

        }

        public int RegisterOpinion(Opinion opinion, int requestId)
        {
            int  result = 0;

            try
            {
                using (var context = new SGPMEntities())
                {
                    Dictamenes dictamen = new Dictamenes
                    {
                        estado = opinion.State,
                        comentario = opinion.Comment,
                        fecha = opinion.Date,
                        NumeroEmpleado = opinion.EmployeeNumber
                    };

                    context.Dictamenes.Add(dictamen);
                    context.SaveChanges();

                    Solicitudes solicitud = context.Solicitudes.Find(requestId);

                    if (solicitud != null)
                    {
                        solicitud.estado = opinion.State;
                        solicitud.IdDictamen = dictamen.IdDictamen;

                        context.SaveChanges();

                        result = dictamen.IdDictamen;
                    }
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
            catch (System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }

        public List<Request> GetRequestsOfProject(string projectId)
        {
            List<Request> requests = new List<Request>();

            try{ 
          
                using (SGPMEntities context = new SGPMEntities())
                {
                    requests = (from r in context.Solicitudes
                                where r.Folio.Equals(projectId) && r.estado.Equals("creada")
                                select new Request
                                {
                                    Id = r.IdSolicitud,
                                    State = r.estado,
                                    CreationTime = (DateTime)r.fechaCreacion,
                                    BeneficiaryId = (int)r.IdBeneficiario,
                                    ProyectFolio = projectId,   
                                }).ToList();
                }
                return requests;
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
            catch (System.Data.EntityException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
