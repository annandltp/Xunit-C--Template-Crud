using CoreServices.Controllers;
using CoreServices.Models;
using CoreServices.Repository;
using CoreServices.ViewModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CoreServices.Test
{
    public class CategoryUnitTestController
    {
        private CategoryRepository repository;
        public static DbContextOptions<BlogDBContext> dbContextOptions { get; }
        static CategoryUnitTestController()
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var connectionString = configuration.GetConnectionString("BlogDBConnection");

            dbContextOptions = new DbContextOptionsBuilder<BlogDBContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public CategoryUnitTestController()
        {
            var context = new BlogDBContext(dbContextOptions);

            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new CategoryRepository(context);

        }
        #region Get By Id  

        [Fact]
        public async void Task_GetCategoryById_Return_OkResult()
        {
            //Arrange  
            var controller = new CategoryController(repository);
            var Id = 1;

            //Act  
            var data = await controller.GetCategories(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        #endregion

    }
}
