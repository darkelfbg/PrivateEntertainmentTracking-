using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
     public enum UserServiceStatusCode
     {
         Ok = 0,

         WrongPassword = 1,

         WrongUserName = 2,

         UserNameTaken = 3,

         Unknown = 4

     }
}
