//using System;
//using Xunit;
//using WebCoreLab.Controllers;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;
//using WebCoreLab.Models;
//using Moq;
//using WebCoreLab.Domain.Context;
//using WebCoreLab.Domain;
//using System.Collections.Generic;

//namespace FestivalsXUnitTest
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void Test1()
//        {
//            // Arrange
//            var controller = new FestivalController(GetMockContextWithData());

//            // Act
//            var result = controller.list() as ViewResult;
//            var festivals = result.Model as List<Festival>;

//            Assert.NotNull(result);
//            Assert.Equal(festivals.Count, 1);

//        }

//        private MyContext GetMockContextWithData()
//        {
//            var options = new DbContextOptionsBuilder<MyContext>()
//                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                              .Options;
//            var context = new MyContext(options);

//            var test = new Festival();
//            test.City = "cit";
//            test.Country = "count";
//            test.Description = "desc";

            
//            context.SaveChanges();

//            return context;
//        }
//    }
//}
