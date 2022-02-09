using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessOnline.Models;
using Microsoft.AspNetCore.Identity;

namespace ChessOnline.IdentityPolicy
{
    public class CustomUSernameEmailPolicy : UserValidator<UserInfo>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<UserInfo> manager, UserInfo user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if(user.UserName == "google")
            {
                errors.Add(new IdentityError
                {
                    Description = "Google cannot be a user name."
                });
            }

            List<String> endings = new List<String>() { "@gmail.com", "@hotmail.com" };

            if(!endings.Any(x => user.Email.ToLower().EndsWith(x)))
            {
                errors.Add(new IdentityError
                {
                    Description = "Only google and hotmail adresses are accepted."
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
