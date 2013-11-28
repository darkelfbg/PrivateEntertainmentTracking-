using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserService;

namespace EntertainmentTrackerPersonal.Models
{
    public class UserModel
    {
        public int Id { get; set;}

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        public bool IsValid(User user)
        {
            return (this.UserName == user.UserName) && (this.Password == user.Password);
        }
    }
}