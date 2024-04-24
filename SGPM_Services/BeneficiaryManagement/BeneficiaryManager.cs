using SGPM_Contracts.IBeneficiaryManagement;
using SGPM_Contracts.IRequestManagement;
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

    public partial class SGPMManager : IBeneficiaryManagement
    {
        public List<Beneficiary> GetBeneficiaries()
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanies(string name)
        {
            List<Company> companies = new List<Company>();
            SGPMEntities context = null;

            try
            {
                context = new SGPMEntities();

                var query = from empresa in context.Empresas
                            join beneficiario in context.Beneficiarios on empresa.IdBeneficiario equals beneficiario.IdBeneficiario
                            where empresa.nombre.ToLower().Contains(name.ToLower())
                            select new { Empresa = empresa, Beneficiario = beneficiario };

                foreach (var result in query)
                {
                    Company company = new Company
                    {
                        Id = result.Empresa.IdEmpresa,
                        Name = result.Empresa.nombre,
                        PhoneNumber = result.Beneficiario.telefono,
                        Street = result.Beneficiario.direccion,
                        BeneficiaryId = result.Beneficiario.IdBeneficiario
                    };

                    companies.Add(company);
                }

                return companies;
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

        public List<Person> GetPersons(string name)
        {
            List<Person> sPersons = new List<Person>();
            try
            {
                using (var context = new SGPMEntities())
                {
                    var query = from persona in context.Personas
                                where persona.nombre.Contains(name)
                                join beneficiario in context.Beneficiarios on persona.IdBeneficiario equals beneficiario.IdBeneficiario
                                select new { Persona = persona, Beneficiario = beneficiario };

                    foreach (var result in query)
                    {
                        Person person = new Person
                        {
                            Id = result.Persona.IdPersona,
                            Name = result.Persona.nombre,
                            LastName = result.Persona.apellidoPaterno,
                            SurName = result.Persona.apellidoMaterno,
                            CURP = result.Persona.curp,
                            PhoneNumber = result.Beneficiario.telefono,
                            Street = result.Beneficiario.direccion,
                            BeneficiaryId = result.Beneficiario.IdBeneficiario
                        };

                        sPersons.Add(person);
                    }
                }
                return sPersons;

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


        int IBeneficiaryManagement.RegisterCompany(Beneficiary beneficiary, Company company)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    Beneficiarios newBeneficiario = new Beneficiarios
                    {
                        telefono = beneficiary.PhoneNumber,
                        tiudad = beneficiary.City,
                        direccion = beneficiary.Street,
                        rfc = beneficiary.RFC
                    };
                    context.Beneficiarios.Add(newBeneficiario);
                    result = context.SaveChanges();

                    if(result > 0)
                    {
                        int beneficiarioId = newBeneficiario.IdBeneficiario;

                        Empresas newEmpresa = new Empresas
                        {
                            nombre = company.Name,
                            IdBeneficiario = beneficiarioId 
                        };

                        context.Empresas.Add(newEmpresa);
                        result = context.SaveChanges();
                    } 
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

        int IBeneficiaryManagement.setBeneficiaryDetails(Beneficiary beneficiary)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    var registeredBeneficiary = context.Beneficiarios.FirstOrDefault(b => b.IdBeneficiario == beneficiary.Id);

                    if (registeredBeneficiary != null)
                    {
                        registeredBeneficiary.telefono = beneficiary.PhoneNumber;
                        registeredBeneficiary.tiudad = beneficiary.City;
                        registeredBeneficiary.direccion = beneficiary.Street;
                        result = context.SaveChanges();
                    }

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

        bool IBeneficiaryManagement.RfcInUse(string rfc)
        {
            bool result = false;
        
                using (var context = new SGPMEntities())
                {
                    result = context.Beneficiarios.Any(b => b.rfc == rfc);
                }
            return result;
        }

        bool IBeneficiaryManagement.CurpInUse(string curp)
        {
            bool result = false;

            using (var context = new SGPMEntities())
            {
                result = context.Personas.Any(b => b.curp == curp);
            }
            return result;
        }

        public int RegisterPerson(Beneficiary beneficiary, Person person)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    Beneficiarios newBeneficiary = new Beneficiarios
                    {
                        telefono = beneficiary.PhoneNumber,
                        tiudad = beneficiary.City,
                        direccion = beneficiary.Street,
                        rfc = beneficiary.RFC
                    };
                    context.Beneficiarios.Add(newBeneficiary);
                    result = context.SaveChanges();

                    if (result > 0)
                    {
                        int beneficiarioId = newBeneficiary.IdBeneficiario;

                        Personas newPersona = new Personas
                        {
                            nombre = person.Name,
                            curp = person.CURP,
                            apellidoPaterno = person.LastName,
                            apellidoMaterno = person.SurName,
                            IdBeneficiario = beneficiarioId
                        };

                        context.Personas.Add(newPersona);
                        result = context.SaveChanges();
                    }
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
