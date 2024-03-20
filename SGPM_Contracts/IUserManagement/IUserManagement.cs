using SGPM_DataBAse;
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
    public interface IUserManagement
    {
        [OperationContract]
        int SaveUser(User user);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int StaffNumber {  get; set; }
    }
}
