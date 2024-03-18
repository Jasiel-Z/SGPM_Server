using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SGPM_Contracts.IRequestManagement;
using SGPM_DataBAse;


namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IRequestManagement
    {
        public Solicitud RecoverRequestDetails(int idRequest)
        {
            throw new NotImplementedException();
        }

        public int RegisterRequest(Solicitud request)
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

        public int RegisterRequestDocumentation(List<Archivo> files)
        {
            int result = 0;
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    foreach (var file in files)
                    {
                        context.ArchivoSet.Add(file);
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
    }
}
