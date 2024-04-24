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
                        Id = (int)result.Empresa.IdBeneficiario,
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
    }
}
