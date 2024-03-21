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

       
    }

    [DataContract]

    public class User
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int EmployeeNumber  { get; set; }


    }


}
