using Microsoft.AspNetCore.Mvc;

namespace AspNetDemo.Web.Controllers;
public class ErrorController : Controller
{
    [HttpGet("error/exception")]
    public IActionResult ServerError()
    {
        return View();
    }

    [HttpGet("error/http/{code}")]
    public IActionResult HttpError(int code)
    {
        return View(code);
    }
}
