using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using AspNetDemo.Web.Views.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AspNetDemo.Web.Controllers;

public class CompaniesController(ICompanyService companyService) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> IndexAsync()
    {
        var model = await companyService.GetAllAsync();
        var viewModel = new IndexVM
        {
            CompanyItems = model
                .Select(o => new IndexVM.CompanyItemVM
                {
                    CompanyName = o.CompanyName,
                })
                .ToArray()
        };
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
        //throw new Exception("test");
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        var model = new Company
        {
            CompanyName = viewModel.CompanyName,
            City = viewModel.City,
        };

        await companyService.AddAsync(model);
        return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
        //return RedirectToAction(nameof(Index));
    }
}
