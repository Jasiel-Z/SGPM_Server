using SGPM_Contracts.IUserManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.UserManagement
{
    public partial class SGPMManager : IUserManagement
    {
        public int SaveUser(User user)
        {
            int result;
            try
            {
                using (var context = new DataBaseModelContainer())
                {
                    UsuarioSet userToBeSaved = new UsuarioSet();
                    userToBeSaved.correo = user.Email;
                    userToBeSaved.contrasena = user.Password;
                    //userToBeSaved.EmpleadoSet = user.StaffNumber;
                    
                    context.UsuarioSet.Add(userToBeSaved);
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
