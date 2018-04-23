using System;
using WebCoreLab.Controllers;
using WebCoreLab.Domain;
using Xunit;

namespace TestingControllers
{
    public class UnitTest1
    {
        [Fact]
        public void EditArtist()
        {
            var controller = new ArtistController();
            Artist artist = new Artist();
            artist.Name = "Name";
            artist.Country = "Country";
            artist.Description = "Some Description";


        }
    }
}
