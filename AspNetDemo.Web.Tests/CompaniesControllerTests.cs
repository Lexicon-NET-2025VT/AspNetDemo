using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using AspNetDemo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AspNetDemo.Web.Tests;

public class CompaniesControllerTests
{
    [Fact]
    public void Index_NoParams_ReturnsViewResult()
    {
        var companyService = new Mock<ICompanyService>();
        companyService
            .Setup(o => o.GetAll())
            .Returns([
                new Company { Id = 1, CompanyName = "Test company 1", City = "London" },
                new Company { Id = 2, CompanyName = "Test company 2", City = "London" },
                new Company { Id = 3, CompanyName = "Test company 3", City = "Malmö" }
                ]);

        var controller = new CompaniesController(companyService.Object);

        var result = controller.Index();

        Assert.IsType<ViewResult>(result);
    }
}
