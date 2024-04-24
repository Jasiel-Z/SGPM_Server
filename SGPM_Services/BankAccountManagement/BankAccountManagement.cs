using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGPM_Contracts.IBankAccountManagement;
using SGPM_DataBAse;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IBankAccountManagement
    {
        public int DeleteBankAccount(int idBeneficiary)
        {
            int result = 1;
            using (var context = new SGPMEntities())
            {
                var banckAccount = context.CuentasBancarias.Where(p => p.IdBeneficiario == idBeneficiary).FirstOrDefault();
                banckAccount.IdBeneficiario = null;
                context.CuentasBancarias.Remove(banckAccount);
                result -= context.SaveChanges();
            }

            return result;
        }

        public BankAccount GetBankAccount(int idBeneficiary)
        {
            BankAccount bankAccountBeneficiary = null;
            using (var context = new SGPMEntities())
            {
                var banckAccount = context.CuentasBancarias.Where(p=>p.IdBeneficiario == idBeneficiary).FirstOrDefault();
                if(banckAccount != null)
                {
                    bankAccountBeneficiary = new BankAccount
                    {
                        Name = banckAccount.titular,
                        AccountNumber = banckAccount.CuentaBancaria
                    };
                }
            }
            return bankAccountBeneficiary;
        }

        public int SaveBankAccount(BankAccount account)
        {
            int result = 1;
            if(account != null)
            {
                if (account.ValidateAccount(account) == 0)
                {
                    using (var context = new SGPMEntities())
                    {
                        CuentasBancarias beneficiaryAccount = new CuentasBancarias
                        {
                            titular = account.Name,
                            CuentaBancaria = account.AccountNumber,
                            IdBeneficiario = account.IdBeneficiary
                        };

                        context.CuentasBancarias.Add(beneficiaryAccount);
                        result -= context.SaveChanges();
                    }
                    UpdateBankAccountBeneficiary(account.IdBeneficiary, account.AccountNumber);
                }
            }
            return result;
        }

        public int UpdateBankAccount(BankAccount account)
        {
            int result = SaveBankAccount(account);

            if (result == 0)
            {
                DeleteBankAccount(account.IdBeneficiary);
            }

            return result;
            
        }

        private int UpdateBankAccountBeneficiary(int idBeneficiary, string idBankAccount) 
        {
            int result = 1;

            using(var context = new SGPMEntities())
            {
                var beneficiary = context.Beneficiarios.Where(p => p.IdBeneficiario == idBeneficiary).FirstOrDefault();
                if(beneficiary != null)
                {
                    beneficiary.CuentaBancaria = idBankAccount;
                }
                result -= context.SaveChanges();
            }

            return result;
        }
    }
}
