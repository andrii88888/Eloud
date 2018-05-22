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
    public class FestivalControllerTest
    { 
        [Fact]
        public void testGetAll()
        {
            var controller = new FestivalController(GetMockContextWithData());
            var result = controller.list(null).Result() as ViewResult;
            var festivals = result.Model as List<Festival>;

            Assert.Equal(4, festivals.Count);
 
            Assert.Equal(festivals, festivalContextList());
        }

        [Fact]
        public void testEditFestival()
        {
            var controller = new FestivalController(GetMockContextWithData());
            var result = controller.list(null).Result() as ViewResult;
            var festivals = result.Model as List<Festival>;

            var fest0 = festivals[0];
            fest0.City = "UpdatedCity";
            controller.edit(fest0);

            var updFestivals = (controller.list(null).Result() as ViewResult).Model as List<Festival>;
            var expectedUpd = festivalContextList();
            expectedUpd[0].City = "UpdatedCity";

            Assert.Equal(updFestivals, expectedUpd);
        }

        [Fact]
        public void testRemoveFestival()
        {
            var controller = new FestivalController(GetMockContextWithData());
            var result = controller.list(null).Result() as ViewResult;
            var festivals = result.Model as List<Festival>;

            controller.remove(festivals[0]);

            var expected = festivalContextList();
            expected.RemoveAt(0);

            var afterRemove = (controller.list(null).Result() as ViewResult).Model as List<Festival>;

            Assert.Equal(afterRemove, expected);
        }

        private ApplicationDbContext GetMockContextWithData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;

            var context = new ApplicationDbContext(options);
            festivalContextList().ForEach((fest) => context.Festivals.Add(fest));
            context.SaveChanges();

            return context;
        }

        private List<Festival> festivalContextList()
        {
            return new List<Festival>()
            {
                new Festival("Name0", "Country0", "City0", new DateTime(2018, 07, 09), new DateTime(2018, 07, 12), "Desc0", "http://link1.jpg"),
                new Festival("Name1", "Country1", "City1", new DateTime(2018, 08, 09), new DateTime(2018, 08, 12), "Desc1", "http://link21.jpg"),
                new Festival("Name2", "Country2", "City2", new DateTime(2018, 09, 09), new DateTime(2018, 09, 12), "Desc2", "http://link21.jpg"),
                new Festival("Name3", "Country3", "City3", new DateTime(2018, 09, 09), new DateTime(2018, 09, 12), "Desc3", "http://link21.jpg")
            };
    }

}
    }

