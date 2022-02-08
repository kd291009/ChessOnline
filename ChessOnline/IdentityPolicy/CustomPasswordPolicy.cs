using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessOnline.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace ChessOnline.IdentityPolicy
{
    public class CustomPasswordPolicy : PasswordValidator<UserInfo>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<UserInfo> manager, UserInfo user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Description = "Password cannot contain username"
                });
            }
            string startsWithUpperOrEndsWithNumber = @"^[A-Z]|[0-9]$";
            Match m = Regex.Match(password, startsWithUpperOrEndsWithNumber);
            if (m.Success)
            {
                errors.Add(new IdentityError
                {
                    Description = "Password should not begin with an upper case letter or end with a number."
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }

    }
}
