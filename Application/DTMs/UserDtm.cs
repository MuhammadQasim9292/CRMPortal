using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs
{
    public record UserCreate(
        string User_Name,
        [EmailAddress]  string Email,
        string Password
        );
    public record UserLogin(
          [Required(ErrorMessage = "Name is required")] string Name,
          [Required(ErrorMessage = "Password is required")] string Password
        );
   
}
