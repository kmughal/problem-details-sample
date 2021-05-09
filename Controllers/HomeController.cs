namespace problem_detail_sample.Controllers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : Controller
    {

        public IActionResult Index(string name)
        {
            try
            {
                if (string.Equals(name, "khurram"))
                {
                    return Ok("good response");
                }
                else
                {
                    throw new Exception("Testing Problem Detail");
                }
            }
            catch (Exception ex)
            {
                var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "Home Controller Index ",
                    Title = ex.Message,
                    Detail = ex.StackTrace,
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }
        }


    }
}
