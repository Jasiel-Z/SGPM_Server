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
        public User GetUser(string email, string password)
        {
            User user = new User();

            try{

                //using(var context = new DataBaseModelContainer())
                //{
                //    user = (from userS in context.UsuarioSet
                //            join empleado in context.EmpleadoSet on userS.IdUsuario equals empleado.Usuario_IdUsuario
                //            where userS.correo == username && userS.contrasena == password
                //            select new User

                //            {
                //                UserId = userS.IdUsuario,
                //                Password = userS.contrasena,
                //                EmployeeNumber = empleado.NumeroEmpleado,
                //                LocationId = empleado.LocalidadIdLocalidad,


                //            }).FirstOrDefault();
                //}

                using (var context = new DataBaseModelContainer())
                {
                    var userSet = context.UsuarioSet.Where(usuario => usuario.contrasena == password
                                                            && usuario.correo == email).FirstOrDefault();
                    var employeeSet = context.EmpleadoSet.Where(empleado => empleado.Usuario_IdUsuario == userSet.IdUsuario).FirstOrDefault();

                    if (userSet != null && employeeSet != null)
                    {
                        user.UserId = userSet.IdUsuario;
                        user.Email = userSet.correo;
                        user.Password = userSet.contrasena;
                        
                        user.EmployeeNumber = employeeSet.NumeroEmpleado;
                        user.Name = employeeSet.nombre;
                        user.MiddleName = employeeSet.apellidoPaterno;
                        user.LastName = employeeSet.apellidoMaterno;
                        user.Role = employeeSet.rol;
                        user.PhoneNumber = employeeSet.telefono;
                        user.City = employeeSet.ciudad;
                        user.Street = employeeSet.calle;
                        user.Number = employeeSet.numero;
                        user.LocationId = employeeSet.LocalidadIdLocalidad;
                    }
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
            int result = 0;
            
            using (var context = new DataBaseModelContainer())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        UsuarioSet userToBeSaved = new UsuarioSet
                        {
                            correo = user.Email,
                            contrasena = user.Password
                        };

                        context.UsuarioSet.Add(userToBeSaved);
                        result = context.SaveChanges();

                        EmpleadoSet employeeToBeSaved = new EmpleadoSet
                        {
                            NumeroEmpleado = user.EmployeeNumber,
                            nombre = user.Name,
                            apellidoPaterno = user.MiddleName,
                            apellidoMaterno = user.LastName,
                            rol = user.Role,
                            ciudad = user.City,
                            calle = user.Street,
                            numero = user.Number,
                            telefono = user.PhoneNumber,
                            LocalidadIdLocalidad = user.LocationId,
                            Usuario_IdUsuario = userToBeSaved.IdUsuario,
                        };

                        context.EmpleadoSet.Add(employeeToBeSaved);
                        result += context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (SqlException exception)
                    {
                        Console.WriteLine(exception.Message);
                        transaction.Rollback();
                        result = -1;
                    }
                    catch (DbEntityValidationException exception)
                    {
                        Console.WriteLine(exception.Message);
                        transaction.Rollback();
                        result = -1;
                    }
                    catch (EntityException exception)
                    {
                        Console.WriteLine(exception.Message);
                        transaction.Rollback();
                        result = -1;
                    }
                }
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

        public bool ValidateEmployeeNumberDoesNotExist(string employeeNumber)
        {
            bool isEmployeeNumberUnique = false;
            int employeeNumberInt = int.Parse(employeeNumber);

            using (var context = new DataBaseModelContainer())
            {
                var employee = context.EmpleadoSet.Where(empleado => empleado.NumeroEmpleado == employeeNumberInt).FirstOrDefault();

                if (employee == null)
                {
                    isEmployeeNumberUnique = true;
                }
            }

            return isEmployeeNumberUnique;
        }
    }
}
