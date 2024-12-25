using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Exceptions
{
    public enum CustomValidationResult : long
    {

        [Display(Name = "Value {Param0} Be {Param1} Negative!")]
        Test1 = 1,
        [Display(Name = "تعداد صندلی ها باید بیش از صفر باشد!")]
        SeatNumberMustBePositiveNumber = 2,
        
    }
}
