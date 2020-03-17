using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace masterLayout.Models
{
    public class loginValidation
    {
        string password;
        string username;

        [Required(ErrorMessage = "username not entered")]
        [StringLength(maximumLength: 25, ErrorMessage = "Maximum length is 25")]
        public string Username { get => username; set => username = value; }
        [Required(ErrorMessage = "password not entered")]
        public string Password { get => password; set => password = value; }

        
    }
}