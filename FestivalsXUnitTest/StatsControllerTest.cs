using System;
using Xunit;
using WebCoreLab.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Domain;
using System.Collections.Generic;
using WebCoreLab.Data;
using WebCoreLab.Models;

namespace FestivalsXUnitTest
{
    public class StatsControllerTest
    {
        [Fact]
        public void testIndex()
        {
            var controller = new StatsController();
            Assert.NotNull(controller.stats());
        }
    }
}
