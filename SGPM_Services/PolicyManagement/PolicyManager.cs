using SGPM_Contracts.IPolicyManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
        public int SavePolicy(Policy policy)
        {
            int result = 0;
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    PoliticaOtorgamientoSet politicaToBeSaved = new PoliticaOtorgamientoSet();
                    politicaToBeSaved.nombre = policy.Name;
                    politicaToBeSaved.descripcion = policy.Description;

                    context.PoliticaOtorgamientoSet.Add(politicaToBeSaved);
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
