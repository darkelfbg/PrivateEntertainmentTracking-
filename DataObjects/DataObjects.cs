using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    [DataContract]
    public class User
    {
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool RememberMe { get; set; }

        public bool IsValid(User user)
        {
            return (UserName == user.UserName) && (Password == user.Password);
        }
    }
}
