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
                using (var context = new SGPMEntities())
                {
                    var userFromDB = context.Usuarios.Where(usuario => usuario.contrasena == password
                                                            && usuario.correo == email).FirstOrDefault();
                    var employeeFromDB = context.Empleados.Where(empleado => empleado.IdUsuario == userFromDB.IdUsuario).FirstOrDefault();

                    if (userFromDB != null && employeeFromDB != null)
                    {
                        user.UserId = userFromDB.IdUsuario;
                        user.Email = userFromDB.correo;
                        user.Password = userFromDB.contrasena;
                        
                        user.EmployeeNumber = employeeFromDB.NumeroEmpleado;
                        user.Name = employeeFromDB.nombre;
                        user.MiddleName = employeeFromDB.apellidoPaterno;
                        user.LastName = employeeFromDB.apellidoMaterno;
                        user.Role = employeeFromDB.rol;
                        user.PhoneNumber = employeeFromDB.telefono;
                        user.City = employeeFromDB.ciudad;
                        user.Street = employeeFromDB.calle;
                        user.Number = (int)employeeFromDB.numeroCasa;
                        user.LocationId = (int)employeeFromDB.IdLocalidad;
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
            
            using (var context = new SGPMEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Usuarios userToBeSaved = new Usuarios
                        {
                            correo = user.Email,
                            contrasena = user.Password
                        };

                        context.Usuarios.Add(userToBeSaved);
                        result = context.SaveChanges();

                        Empleados employeeToBeSaved = new Empleados
                        {
                            NumeroEmpleado = user.EmployeeNumber,
                            nombre = user.Name,
                            apellidoPaterno = user.MiddleName,
                            apellidoMaterno = user.LastName,
                            rol = user.Role,
                            ciudad = user.City,
                            calle = user.Street,
                            numeroCasa = user.Number,
                            telefono = user.PhoneNumber,
                            IdLocalidad = user.LocationId,
                            IdUsuario = userToBeSaved.IdUsuario,
                        };

                        context.Empleados.Add(employeeToBeSaved);
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

            using (var context = new SGPMEntities())
            {
                var User = context.Usuarios.Where(usuario => usuario.correo == email).FirstOrDefault();

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

            using (var context = new SGPMEntities())
            {
                var employee = context.Empleados.Where(empleado => empleado.NumeroEmpleado == employeeNumberInt).FirstOrDefault();

                if (employee == null)
                {
                    isEmployeeNumberUnique = true;
                }
            }

            return isEmployeeNumberUnique;
        }
    }
}
