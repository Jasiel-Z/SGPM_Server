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
            DataBaseModelContainer context = null;

            try
            {
                context = new DataBaseModelContainer();

                var query = from empresa in context.empresaSet
                            join beneficiario in context.BeneficiarioSet on empresa.Beneficiario_idBeneficiario equals beneficiario.idBeneficiario
                            where empresa.nombre.ToLower().Contains(name.ToLower())
                            select new { Empresa = empresa, Beneficiario = beneficiario };

                foreach (var result in query)
                {
                    Company company = new Company
                    {
                        Id = result.Empresa.idBeneficiario,
                        Name = result.Empresa.nombre,
                        PhoneNumber = result.Beneficiario.telefono,
                        Street = result.Beneficiario.calle,
                        BeneficiaryId = result.Beneficiario.idBeneficiario
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
                using (var context = new DataBaseModelContainer())
                {
                    var query = from persona in context.PersonaSet
                                where persona.nombre.Contains(name)
                                join beneficiario in context.BeneficiarioSet on persona.Beneficiario_idBeneficiario equals beneficiario.idBeneficiario
                                select new { Persona = persona, Beneficiario = beneficiario };

                    foreach (var result in query)
                    {
                        Person person = new Person
                        {
                            Id = result.Persona.idBeneficiario,
                            Name = result.Persona.nombre,
                            LastName = result.Persona.apellidoPaterno,
                            SurName = result.Persona.apellidoMaterno,
                            CURP = result.Persona.curp,
                            PhoneNumber = result.Beneficiario.telefono,
                            Street = result.Beneficiario.calle,
                            BeneficiaryId = result.Persona.Beneficiario_idBeneficiario
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
