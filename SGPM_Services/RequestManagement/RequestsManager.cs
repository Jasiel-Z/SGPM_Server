using System;
using System.CodeDom;
using System.Collections.Generic;
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
                using (var context = new DataBaseModelContainer())
                {
                    request = (from req in context.SolicitudSet
                                 where req.IdSolicitud == idRequest
                                 select new Request
                                 {
                                     Id = req.IdSolicitud,
                                     CreationTime = req.fechaCreacion,
                                     BeneficiaryId = (int)req.BeneficiarioId,
                                    
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
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                request = null;
            }


            return request;
        }

        public int RegisterRequest(SolicitudSet request)
        {
            int result = 0;
            try
            {
                using(var context = new DataBaseModelContainer())
                {
                    context.SolicitudSet.Add(request);
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
            catch(EntityException exception)
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
                using (var context = new DataBaseModelContainer())
                {
                    foreach (var file in files)
                    {

                        ArchivoSet archivoSet = new ArchivoSet()
                        {
                            nombre = file.Name,
                            extension = file.Extension,
                            contenido = new byte[0],
                            descripcion = file.Description,
                            SolicitudIdSolicitud = 1
                        };
                        context.ArchivoSet.Add(archivoSet);
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



        public int RegisterRequestWithDocuments(SolicitudSet request, List<SGPM_Contracts.IRequestManagement.File> files)
        {
            int result = 0;
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    context.SolicitudSet.Add(request);
                    context.SaveChanges();

                    int solicitudId = request.IdSolicitud;

                    foreach (var file in files)
                    {
                        ArchivoSet archivoSet = new ArchivoSet()
                        {
                            nombre = file.Name,
                            extension = file.Extension,
                            contenido = new byte[0],
                            descripcion = file.Description,
                            SolicitudIdSolicitud = solicitudId
                            
                        };
                        context.ArchivoSet.Add(archivoSet);
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


        public bool BeneficiaryHasRequest(int beneficiaryId, int projectFolio)
        {
            bool result = false;
            using (var context = new DataBaseModelContainer())
            {
            result = context.SolicitudSet.Any(s => s.BeneficiarioId == beneficiaryId && s.ProyectoFolio == projectFolio);
            }

            return result;
        }


        public List<SGPM_Contracts.IRequestManagement.File> GetRequestFiles(int requestId)
        {
            List<SGPM_Contracts.IRequestManagement.File> files = new List<SGPM_Contracts.IRequestManagement.File>();
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    files = (from file in context.ArchivoSet
                             where file.SolicitudIdSolicitud == requestId
                             select new SGPM_Contracts.IRequestManagement.File
                             {
                                 Name = file.nombre,
                                 Extension = file.extension,
                                 Description = file.descripcion,
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
            catch (EntityException exception)
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
                using (var context = new DataBaseModelContainer())
                {
                    DictamenSet dictamen = new DictamenSet
                    {
                        estado = opinion.State,
                        comentarios = opinion.Comment,
                        fecha = opinion.Date,
                        EmpleadoNumeroEmpleado = opinion.EmployeeNumber
                    };

                    context.DictamenSet.Add(dictamen);
                    context.SaveChanges();

                    SolicitudSet solicitud = context.SolicitudSet.Find(requestId);

                    if (solicitud != null)
                    {
                        solicitud.estado = opinion.State;
                        solicitud.Dictamen_IdDictamen = dictamen.IdDictamen;

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
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }

        public List<Request> GetRequestsOfProject(int projectId)
        {
            List<Request> requests = new List<Request>();

            try{ 
          
                using (var context = new DataBaseModelContainer())
                {
                    requests = (from r in context.SolicitudSet
                                where r.ProyectoFolio == projectId
                                select new Request
                                {
                                    Id = r.IdSolicitud,
                                    State = r.estado,
                                    CreationTime = r.fechaCreacion,
                                    BeneficiaryId = (int)r.BeneficiarioId,
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
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
