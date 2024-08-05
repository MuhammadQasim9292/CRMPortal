using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs.User
{
    public record UserCreateDTM(
        string User_Name,
        [EmailAddress] string Email,
        string Password
        );
}
