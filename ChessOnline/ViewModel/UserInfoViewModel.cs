using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessOnline.ViewModel
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required."), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required."), Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email adress is required."), EmailAddress(ErrorMessage = "Invalid email adress.")]
        [Display(Name = "Email Adress")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Password is required."), Display(Name = "Password") ]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
