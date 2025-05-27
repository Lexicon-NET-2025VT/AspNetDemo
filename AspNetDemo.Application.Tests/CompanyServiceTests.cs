using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using Moq;
using System.Diagnostics;

namespace AspNetDemo.Application.Tests;

public class CompanyServiceTests
{
    [Fact]
    public void GetById_ValidId_ReturnsCompany()
    {
        // Arrage
        var companyRepository = new Mock<ICompanyRepository>();
        companyRepository
            .Setup(o => o.GetById(1))
            .Returns(new Company { Id = 1, CompanyName = "Acme", City = "London" });

        //var companyService = new CompanyService(new TestCompanyRepository());
        var companyService = new CompanyService(companyRepository.Object);

        // Act
        var result = companyService.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Company>(result);
        companyRepository.Verify(o => o.GetById(1), Times.Exactly(1));
        //Debug.Assert(true);
    }

    [Fact]
    public void GetById_InvalidId_ThrowsArgumentException()
    {
        // Arrage
        var companyRepository = new Mock<ICompanyRepository>();

        // Denna rad säger att ICompanyRepository.GetById() kastar ett ArgumentException
        // Kan kommenteras bort om vi bara vill testa att servicen själv slänger felet
        companyRepository
            .Setup(o => o.GetById(0))
            .Throws<ArgumentException>();

        var companyService = new CompanyService(companyRepository.Object);

        // Act
        var result = Record.Exception(() => companyService.GetById(0));

        // Assert
        Assert.IsType<ArgumentException>(result);
    }

    [Fact]
    public async Task Add_ShouldCapitalizeCompanyName()
    {
        // Arrange
        var mockRepository = new Mock<ICompanyRepository>();
        var service = new CompanyService(mockRepository.Object);
        
        // Act
        await service.AddAsync(
            new Company { Id = 1, CompanyName = "test Company", City = "London" });

        // Assert
        // Verifiera att ICompanyRepository.AddAsync() anropades en gång (med korrekt namn)
        mockRepository.Verify(o => o.AddAsync(It.Is<Company>(
            o => o.CompanyName == "Test Company")), Times.Once);
    }

    class TestCompanyRepository : ICompanyRepository
    {
        public Task AddAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Company[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Company? GetById(int id)
        {
            return new Company { Id = id, CompanyName = "Acme", City = "London" };
        }
    }
}
