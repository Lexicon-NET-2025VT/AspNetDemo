using AspNetDemo.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetDemo.Web.Controllers;


public class CompaniesController : Controller
{
    CompanyService companyService = new CompanyService();

    [Route("")]
    public IActionResult Index()
    {
        var model = companyService.GetAll();
        return View(model);
    }

    [Route("details/{id}")]
    public IActionResult Details(int id)
    {
        return Content($"I Details, Id: {id}");
    }
}
