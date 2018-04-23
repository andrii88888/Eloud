using System;
using Xunit;
using WebCoreLab.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Domain;
using System.Collections.Generic;
using WebCoreLab.Data;

namespace FestivalsXUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var controller = new FestivalController(GetMockContextWithData());

            // Act
            var result = controller.list() as ViewResult;
            var festivals = result.Model as List<Festival>;

            Assert.NotNull(result);
            Assert.Equal(festivals.Count, 1);

        }

        private ApplicationDbContext GetMockContextWithData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;

            var context = new ApplicationDbContext(options);

            var test = new Festival();
            test.City = "cit";
            test.Country = "count";
            test.Description = "desc";

            context.Festivals.Add(test);
            context.SaveChanges();

            return context;
        }
    }
}
