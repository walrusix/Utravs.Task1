using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Exceptions
{
    public enum CustomApiResultStatusCode
    {
        [Display(Name = "Success!")]
        Success = 0,

        [Display(Name = "Internal Server Error!")]
        ServerError = 1,

        [Display(Name = "Invalid Parameter(s)!")]
        BadRequest = 2,

        [Display(Name = "Not Found!")]
        NotFound = 3,

        [Display(Name = "Authorization Error!")]
        UnAuthorized = 6,

        [Display(Name = "Validation Error! (for more details see error list.)")]
        ValidationError = 1010,
    }
}
