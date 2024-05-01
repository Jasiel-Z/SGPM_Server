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
        public List<Beneficiary> GetBeneficiaries(int localityId)
        {
            List<Beneficiary> beneficiaries = new List<Beneficiary>();
            try
            {
                using (var context = new SGPMEntities())
                {
                    var query = from benef in context.Beneficiarios where benef.IdLocalidad == localityId
                                select
                                benef;
                    foreach (var benefDb in query)
                    {
                        Beneficiary beneficiary = new Beneficiary
                        {
                            Id = benefDb.IdBeneficiario,
                            City = benefDb.tiudad,
                            RFC = benefDb.rfc,
                            Street = benefDb.direccion,
                            PhoneNumber = benefDb.telefono,
                            CompanyId = benefDb.IdEmpresa != null ? (int)benefDb.IdEmpresa.GetValueOrDefault() : 0,
                            PersonId = benefDb.IdPersona != null ? (int)benefDb.IdPersona.GetValueOrDefault() : 0,
                            AccountId = !string.IsNullOrEmpty(benefDb.CuentaBancaria) ? benefDb.CuentaBancaria : "N/A"

                        };
                        beneficiaries.Add(beneficiary);
                    }
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
                    Beneficiarios newBeneficiary = new Beneficiarios
                    {
                        telefono = beneficiary.PhoneNumber,
                        tiudad = beneficiary.City,
                        direccion = beneficiary.Street,
                        rfc = beneficiary.RFC,
                        IdLocalidad = beneficiary.LocalityId
                        
                    };
                    context.Beneficiarios.Add(newBeneficiary);
                    result = context.SaveChanges();

                    if (result > 0)
                    {
                        int beneficiarioId = newBeneficiary.IdBeneficiario;

                        Empresas newEmpresa = new Empresas
                        {
                            nombre = company.Name,
                            IdBeneficiario = beneficiarioId
                        };

                        context.Empresas.Add(newEmpresa);
                        result = context.SaveChanges();

                        newBeneficiary.IdEmpresa = newEmpresa.IdEmpresa;
                        context.SaveChanges();
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
                        rfc = beneficiary.RFC,
                        IdLocalidad = beneficiary.LocalityId
                    };
                    context.Beneficiarios.Add(newBeneficiary);
                    result = context.SaveChanges();

                    if (result > 0)
                    {
                        int beneficiaryId = newBeneficiary.IdBeneficiario;

                        Personas newPersona = new Personas
                        {
                            nombre = person.Name,
                            curp = person.CURP,
                            apellidoPaterno = person.LastName,
                            apellidoMaterno = person.SurName,
                            IdBeneficiario = beneficiaryId
                        };

                        context.Personas.Add(newPersona);
                        result = context.SaveChanges();

                        newBeneficiary.IdPersona = newPersona.IdPersona;
                        context.SaveChanges();
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

        Person IBeneficiaryManagement.getPerson(int beneficiaryId)
        {
            SGPMEntities context = null;
            try
            {
                context = new SGPMEntities();
                Personas personDb = context.Personas.FirstOrDefault(p => p.IdBeneficiario == beneficiaryId);

                if (personDb != null)
                {
                    Person person = new Person
                    {
                        Name = personDb.nombre,
                        LastName = personDb.apellidoPaterno,
                        SurName = personDb.apellidoMaterno,
                        CURP = personDb.curp,
                        BeneficiaryId = beneficiaryId

                    };

                    return person;
                }
                else
                {
                    return null;
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

        Company IBeneficiaryManagement.getCompany(int beneficiaryId)
        {
            SGPMEntities context = null;
            try
            {
                context = new SGPMEntities();
                Empresas companyDb = context.Empresas.FirstOrDefault(p => p.IdBeneficiario == beneficiaryId);

                if (companyDb != null)
                {
                    Company company = new Company
                    {
                        Name = companyDb.nombre,
                        BeneficiaryId = beneficiaryId

                    };

                    return company;
                }
                else
                {
                    return null;
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
