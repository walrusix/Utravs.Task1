using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Exceptions
{
    public class ValidationErrorResult
    {

        //public ValidationErrorResult(CustomValidationResult result, string param)
        //{
        //    Type = ErrorResultType.General.ToString();
        //    this.Status = result.ToString();
        //    this.Param = param;
        //    this.Description = result.ToDisplay();
        //}

        public ValidationErrorResult(CustomValidationResult result, string field)
        {
            this.Status = result;
            this.Param = field;
        }
        public ValidationErrorResult(CustomValidationResult result, string field, params string[] paramList)
        {
            this.Status = result;
            this.Param = field;
            this.Params = paramList;
            
        }

        public string Type { set; get; }
        public CustomValidationResult Status { set; get; }
        public string Description { set; get; }
        public string Param { set; get; }
        public string[] Params { set; get; }


    }
}
