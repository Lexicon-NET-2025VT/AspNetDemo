using AspNetDemo.Web.Models;
using AspNetDemo.Web.Services;
using AspNetDemo.Web.Views.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AspNetDemo.Web.Controllers;

public class CompaniesController(
    CompanyService companyService,
    ILogger<CompaniesController> logger) : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var model = companyService.GetAll();
        var viewModel = new IndexVM
        {
            CompanyItems = model
                .Select(o => new IndexVM.CompanyItemVM
                {
                    CompanyName = o.CompanyName,
                })
                .ToArray()
        };
        logger.LogInformation($"Companies: {viewModel.CompanyItems.Length}");
        return View(viewModel);
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
    public IActionResult Create(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        var model = new Company
        {
            CompanyName = viewModel.CompanyName,
            City = viewModel.City,
        };

        companyService.Add(model);
        return RedirectToAction(nameof(Index));
    }
}
