using Microsoft.VisualStudio.TestTools.UnitTesting;
using core10_swapi.Models;
using core10_swapi.ModelServices;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace core10_swapi_test
{
    [TestClass]
    public class SwapiServicesTest
    {
        
            private SwapiServices _controller;
            private Mock<ILogger<SwapiServices>> _logger;

            [TestInitialize]
            public void Init()
            {
                _logger = new Mock<ILogger<SwapiServices>>();
 
            }


            [TestMethod]
            public async Task GetCharacterBiographyResultCount()
            {
                _controller = new SwapiServices(_logger.Object);
                var apiresponse = await _controller.GetCharacterBiography<Character>("Luke Skywalker");
                
                Assert.AreEqual(apiresponse.results.Count, 1);
            }

            [TestMethod]
            public async Task GetCharacterBiographyStarshipCount()
            {
                _controller = new SwapiServices(_logger.Object);
                var apiresponse = await _controller.GetCharacterBiography<Character>("Luke Skywalker");

                Assert.AreEqual(apiresponse.results[0].starships.Count, 2);
            }

            [TestMethod]
            public async Task GetCharacterBiographyDataCount()
            {
                _controller = new SwapiServices(_logger.Object);
                var apiresponse = await _controller.GetCharacterBiography<Character>("Luke Skywalker");

                Assert.AreEqual(apiresponse.count, 1);
            }   




    }
}