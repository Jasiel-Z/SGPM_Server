using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SGPM_Contracts.IBankAccountManagement
{
    [ServiceContract]
    public interface IBankAccountManagement
    {
        [OperationContract]
        int SaveBankAccount(BankAccount account);

        [OperationContract]
        int UpdateBankAccount(BankAccount account);


        [OperationContract]
        BankAccount GetBankAccount(int idBeneficiary);
    }

    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public int IdBeneficiary { set; get; }
        [DataMember]
        public string Name { set; get; }
        [DataMember]
        public string AccountNumber { set; get; }

        public int ValidateAccount(BankAccount account)
        {
            int result = 0;

            if (!Regex.IsMatch(account.Name, @"^[\p{L} \.\-]+$") || account.Name.Length < 9)
            {
                result = 1;
            }

            if (result == 0)
            {
                if (account.AccountNumber.Length != 18)
                {
                    result = 1;
                }
            }

            return result;
        }
    }
}
