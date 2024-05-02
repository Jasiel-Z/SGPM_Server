using SGPM_Contracts.IRequestManagement;
using SGPM_Contracts.IUserManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
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

        public List<User> GetUsersGeneralInfo(int pageNumber)
        {
            List<User> users = new List<User>();

            try
            {
                using (var context = new SGPMEntities())
                {
                    var orderedEmployees = context.Empleados
                                              .OrderBy(e => e.apellidoPaterno)
                                              .ThenBy(e => e.nombre)
                                              .Select(e => new
                                              {
                                                  e.NumeroEmpleado,
                                                  e.nombre,
                                                  e.apellidoPaterno,
                                                  e.apellidoMaterno
                                              })
                                              .Skip((pageNumber - 1) * 50)
                                              .Take(50)
                                              .ToList();

                    foreach (var employee in orderedEmployees)
                    {
                        User user = new User
                        {
                            EmployeeNumber = employee.NumeroEmpleado,
                            Name = employee.nombre,
                            MiddleName = employee.apellidoPaterno,
                            LastName = employee.apellidoMaterno
                        };

                        users.Add(user);
                    }
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                users = null;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                users = null;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                users = null;
            }

            return users;
        }

        public User GetUserDetailsByEmployeeNumber(int employeeNumber)
        {
            User user;

            try
            {
                using (var context = new SGPMEntities())
                {
                    var employeeFromDB = context.Empleados.Where(e => e.NumeroEmpleado == employeeNumber)
                                                .Select(e => new
                                                {
                                                    e.telefono,
                                                    e.rol,
                                                    e.calle,
                                                    e.ciudad,
                                                    e.numeroCasa,
                                                    e.IdLocalidad,
                                                    e.IdUsuario
                                                })
                                                .FirstOrDefault();

                    var userFromDB = context.Usuarios.Where(u => u.IdUsuario == employeeFromDB.IdUsuario)
                                                     .Select(u => new
                                                     {
                                                         u.correo
                                                     })
                                                     .FirstOrDefault();

                    user = new User
                    {
                        PhoneNumber = employeeFromDB.telefono,
                        Role = employeeFromDB.rol,
                        Street = employeeFromDB.calle,
                        City = employeeFromDB.ciudad,
                        Number = (int)employeeFromDB.numeroCasa,
                        LocationId = (int)employeeFromDB.IdLocalidad,
                        UserId = (int)employeeFromDB.IdUsuario,
                        Email = userFromDB.correo
                    };
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
                            contrasena = user.Password,
                            NumeroEmpleado = user.EmployeeNumber
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

        public int UpdateUser(User user)
        {
            int result = 0;
            
            using (var context = new SGPMEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var userFromDB = context.Usuarios
                                                .Where(u => u.correo == user.Email)
                                                .SingleOrDefault();

                        if (userFromDB != null)
                        {
                            userFromDB.correo = user.Email;
                            if (!string.IsNullOrEmpty(user.Password))
                            {
                                userFromDB.contrasena = user.Password;
                            }

                            result += context.SaveChanges();
                        }
                        
                        var employeeFromDB = context.Empleados
                                                    .Where(e => e.NumeroEmpleado == user.EmployeeNumber)
                                                    .SingleOrDefault();

                        if (employeeFromDB != null)
                        {
                            employeeFromDB.rol = user.Role;
                            employeeFromDB.telefono = user.PhoneNumber;
                            employeeFromDB.nombre = user.Name;
                            employeeFromDB.apellidoPaterno = user.MiddleName;
                            employeeFromDB.apellidoMaterno = user.LastName;
                            employeeFromDB.ciudad = user.City;
                            employeeFromDB.calle = user.Street;
                            employeeFromDB.numeroCasa = user.Number;
                            employeeFromDB.IdLocalidad = user.LocationId;

                            result += context.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex) when (ex is DbUpdateException || ex is DbEntityValidationException || ex is InvalidOperationException || ex is SqlException)
                    {
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
