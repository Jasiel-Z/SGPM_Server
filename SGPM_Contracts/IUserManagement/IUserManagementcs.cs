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
        User GetUser(string email, string password);

        [OperationContract]
        List<User> GetUsersGeneralInfo(int pageNumber);

        [OperationContract]
        User GetUserDetailsByEmployeeNumber(int employeeNumber);

        [OperationContract]
        int SaveUser(User user);

        [OperationContract]
        int UpdateUser(User user);

        [OperationContract]
        bool ValidateEmailDoesNotExist(string email);

        [OperationContract]
        bool ValidateEmployeeNumberDoesNotExist(string employeeNumber);
    }

    [DataContract]

    public class User
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Role {  get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string City{ get; set; }

        [DataMember]
        public string Street {  get; set; }

        [DataMember]
        public int Number { get; set; }

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
