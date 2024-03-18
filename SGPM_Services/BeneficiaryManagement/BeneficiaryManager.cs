using SGPM_Contracts.IBeneficiaryManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{

    public partial class SGPMManager: IBeneficiaryManagement
    {
        List<Beneficiario> IBeneficiaryManagement.GetBeneficiaries()
        {
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    List<Beneficiario> beneficiaries = context.BeneficiarioSet.ToList();
                    return beneficiaries;

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
    }
}
