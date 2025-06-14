﻿using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using Moq;
using System.Diagnostics;

namespace AspNetDemo.Application.Tests;

public class CompanyServiceTests
{
    [Fact]
    public async Task GetById_ValidId_ReturnsCompanyAsync()
    {
        // Arrage
        var companyRepository = new Mock<ICompanyRepository>();
        companyRepository
            .Setup(o => o.GetByIdAsync(1))
            .ReturnsAsync(new Company { Id = 1, CompanyName = "Acme", City = "London" });

        var unitOfWork = Mock.Of<IUnitOfWork>(u => u.Companies == companyRepository.Object);
        var companyService = new CompanyService(unitOfWork);

        // Act
        var result = await companyService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Company>(result);
        companyRepository.Verify(o => o.GetByIdAsync(1), Times.Exactly(1));
        //Debug.Assert(true);
    }

    [Fact]
    public async Task GetById_InvalidId_ThrowsArgumentExceptionAsync()
    {
        // Arrage
        var companyRepository = new Mock<ICompanyRepository>();

        // Denna rad säger att ICompanyRepository.GetById() kastar ett ArgumentException
        // Kan kommenteras bort om vi bara vill testa att servicen själv slänger felet
        companyRepository
            .Setup(o => o.GetByIdAsync(0))
            .Throws<ArgumentException>();

        var unitOfWork = Mock.Of<IUnitOfWork>(u => u.Companies == companyRepository.Object);
        var companyService = new CompanyService(unitOfWork);

        // Act
        var result = await Record.ExceptionAsync(() => companyService.GetByIdAsync(0));

        // Assert
        Assert.IsType<ArgumentException>(result);
    }

    [Fact]
    public async Task Add_ShouldCapitalizeCompanyName()
    {
        // Arrange
        var companyRepository = new Mock<ICompanyRepository>();
        var unitOfWork = Mock.Of<IUnitOfWork>(u => u.Companies == companyRepository.Object);
        var service = new CompanyService(unitOfWork);
        
        // Act
        await service.AddAsync(
            new Company { Id = 1, CompanyName = "test Company", City = "London" });

        // Assert
        // Verifiera att ICompanyRepository.AddAsync() anropades en gång (med korrekt namn)
        companyRepository.Verify(o => o.Add(It.Is<Company>(
            o => o.CompanyName == "Test Company")), Times.Once);
    }

    //class TestCompanyRepository : ICompanyRepository
    //{
    //    public Task AddAsync(Company company)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Company[] GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Company? GetByIdAsync(int id)
    //    {
    //        return new Company { Id = id, CompanyName = "Acme", City = "London" };
    //    }
    //}
}
