using AspNetDemo.Web.Models;
using AspNetDemo.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AspNetDemo.Web.Controllers;

public class CompaniesController : Controller
{
    static CompanyService companyService = new CompanyService();

    public CompaniesController()
    {
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var model = companyService.GetAll();
        return View(model);
    }

    [HttpGet("details/{id}")]
    public IActionResult Details(int id, string name, int age)
    {
        //return Json(new { Name = "Lille Bo", Age = 5 });
        return Content($"I Details, Id: {id}");
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(Company company)
    {
        companyService.Add(company);
        //return Content("done");
        return RedirectToAction(nameof(Index));
    }
}
