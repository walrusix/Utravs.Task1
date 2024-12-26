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
        [Display(Name = "مقدار این فیلد باید بیش از صفر باشد!")]
        ValueMustBePositiveNumber = 2,
        [Display(Name = "این فیلد الزامی می باشد!")]
        ThisFieldIsRequired = 3,
        [Display(Name = "فرمت وارد شده برای این فیلد صحیح نمی باشد!")]
        InvalidFormat = 4,
        [Display(Name = "مقدار وارد شده برای این فیلد صحیح نمی باشد!")]
        InvalidValue = 5,
        [Display(Name = "تعداد صندلی موردنظر موجود نمی باشد!")]
        ThereIsNoEnoughSeats = 6,

    }
}
