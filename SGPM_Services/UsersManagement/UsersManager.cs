using SGPM_Contracts.IRequestManagement;
using SGPM_Contracts.IUserManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IUserManagement
    {
        public User GetUser(string username, string password)
        {
            User user = new User();

            try{

                using(var context = new DataBaseModelContainer())
                {
                    user = (from userS in context.UsuarioSet
                            join empleado in context.EmpleadoSet on userS.IdUsuario equals empleado.Usuario_IdUsuario
                            where userS.correo == username && userS.contrasena == password
                            select new User
                        
                            {
                                UserId = userS.IdUsuario,
                                Password = userS.contrasena,
                                EmployeeNumber = empleado.NumeroEmpleado,
                                LocationId = empleado.LocalidadIdLocalidad,


                            }).FirstOrDefault();
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                user = null;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                user = null;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                user = null;
            }


            return user;
        }

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

        public bool ValidateEmailDoesNotExist(string email)
        {
            bool isEmailUnique = false;

            using (var context = new DataBaseModelContainer())
            {
                var User = context.UsuarioSet.Where(usuario => usuario.correo == email).FirstOrDefault();

                if (User == null)
                {
                    isEmailUnique = true;
                }
            }

            return isEmailUnique;
        }

        public bool ValidateStaffNumberDoesNotExist(string staffNumber)
        {
            bool isStaffNumberUnique = false;

            /*using (var context = new DataBaseModelContainer())
            {
                var User = context.UsuarioSet.Where(usuario => usuario.NumeroEmpleado == staffNumber).FirstOrDefault();

                if (User == null)
                {
                    isStaffNumberUnique = true;
                }
            }*/

            return isStaffNumberUnique;
        }
    }
}
