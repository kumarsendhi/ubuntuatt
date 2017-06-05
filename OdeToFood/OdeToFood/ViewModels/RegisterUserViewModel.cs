using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(80)]
        public string UserName { get; set; }
        [Required,MaxLength(80)]
        public string FirstName { get; set; }
        [Required, MaxLength(80)]
        public string LastName { get; set; }
        [Required,  DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,  DataType(DataType.EmailAddress)]
        public string AlternateEmail { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(80)]
        public string Organisation { get; set; }
        [Required, MaxLength(80)]
        public string Position { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
