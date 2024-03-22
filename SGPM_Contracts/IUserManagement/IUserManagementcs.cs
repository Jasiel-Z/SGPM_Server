using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Contracts.IUserManagement
{
    [ServiceContract]
    public  interface IUserManagement
    {
        [OperationContract]
        User GetUser(string username, string password);

        [OperationContract]
        int SaveUser(User user);

        [OperationContract]
        bool ValidateEmailDoesNotExist(string email);

        [OperationContract]
        bool ValidateStaffNumberDoesNotExist(string staffNumber);
    }

    [DataContract]

    public class User
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int EmployeeNumber  { get; set; }

        [DataMember]
        public int LocationId { get; set; }


    }


}
