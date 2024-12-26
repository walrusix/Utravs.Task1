using Microsoft.AspNetCore.Mvc;
using Utravs.Task1.EndPoints.WebApi.Filters;

namespace Utravs.Task1.EndPoints.WebApi
{
    [ApiController]
    [ApiResultFilter]
    [Route("[controller]")]
    public class EndUserBaseController : ControllerBase
    {
    }
}
