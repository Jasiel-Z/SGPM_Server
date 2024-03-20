using SGPM_Contracts.ILocalityManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : ILocalityManagement
    {
        public int SaveLocality(Locality locality)
        {
            int result = 0;
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    LocalidadSet localityToBeSaved = new LocalidadSet();
                    localityToBeSaved.nombre = locality.Name;

                    context.LocalidadSet.Add(localityToBeSaved);
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
