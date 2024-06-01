using SGPM_Contracts.IEvidenceManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IEvidenceManagement
    {
        public List<ProjectShow> GetFinishProjectsd()
        {
            DateTime todayDate = DateTime.Now;
            List<ProjectShow> projectList = new List<ProjectShow>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    var projectListDB = context.Proyectos.Where(p => p.fechaFin < todayDate && p.fechaLimiteEvidencias > todayDate).ToList();
                    foreach (var project in projectListDB)
                    {
                        var projectShow = new ProjectShow
                        {
                            Folio = project.Folio,
                            Name = project.nombre
                        };
                        projectList.Add(projectShow);
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

            return projectList;
        }

        public List<RequestShow> GetFinishRequestsd(string folio)
        {
            DateTime todayDate = DateTime.Now;
            List<RequestShow> projectList = new List<RequestShow>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    var requestListDB = context.Solicitudes.Where(s => s.Folio == folio).ToList();
                    foreach (var request in requestListDB)
                    {
                        var RequestShow = new RequestShow
                        {
                            Id = request.IdSolicitud,
                            BeneficiaryName = request.Beneficiarios.rfc
                        };
                        projectList.Add(RequestShow);
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

            return projectList;
        }

        public int SaveEvidence(Evidence evidence)
        {
            int result = 0;

            try
            {
                using (var context = new SGPMEntities())
                {
                    Evidencias solicitud = new Evidencias
                    {
                        nombre = evidence.Name,
                        fechaEntrega = DateTime.Now,
                        direccion = "../EvidenceFIles/",
                        IdSolicitud = evidence.IdRequest
                    };
                    context.Evidencias.Add(solicitud);
                    result = context.SaveChanges();
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


            if (result != 0)
            {
                var file = DecompressFile(evidence.file);
                SaveFile(file, evidence.Name);
            }

            return result;
        }

        public byte[] DecompressFile(byte[] compressedBytes)
        {
            using (var compressedStream = new MemoryStream(compressedBytes))
            {
                using (var decompressedStream = new MemoryStream())
                {
                    using (var decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedStream);
                    }
                    return decompressedStream.ToArray();
                }
            }
        }

        public void SaveFile(byte[] fileBytes, string fileName)
        {
            string directoryPath = "/EvidenceFIles\\";
            string filePath = Path.Combine(directoryPath, fileName); 

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllBytes(filePath, fileBytes);

                Console.WriteLine($"Archivo guardado en: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
        }
    }
}
