using SGPM_Contracts.IEvidenceManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IEvidenceManagement
    {
        public List<ProjectShow> GetFinishProjectsd()
        {
            DateTime todayDate = DateTime.Now;
            List<ProjectShow> projectList = new List<ProjectShow>();
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
            return projectList;
        }

        public List<RequestShow> GetFinishRequestsd(string folio)
        {
            DateTime todayDate = DateTime.Now;
            List<RequestShow> projectList = new List<RequestShow>();
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
            return projectList;
        }

        public int SaveEvidence(Evidence evidence)
        {
            Console.WriteLine("EY");
            int result = 0;
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
            var file = DecompressFile(evidence.file);
            SaveFile(file, evidence.Name);
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
            string directoryPath = "C:\\Users\\yusgu\\Documents\\UV\\6to Semestre\\D. Software\\SGPM_Server\\SGPM_Services\\EvidenceManagement\\EvidenceFIles\\";
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
