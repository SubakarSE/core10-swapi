using Microsoft.VisualStudio.TestTools.UnitTesting;
using core10_swapi.Models;
using core10_swapi;
using core10_swapi.ModelBuilders;
using core10_swapi.Controllers;
using Microsoft.Extensions.Logging;

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
using NUnit.Framework;
using core10_swapi.ModelServices;

namespace core10_swapi_test.Unit.Tests
{
    [TestClass]
    public class SwapiControllerTest
    {
        private SwapiController _swapiController;
        private Mock<ISwapiServices> _mockISwapiServices;
        private Mock<ILogger<SwapiController>> _mocklogger;
        private Mock<ILogger<SwapiModelBuilder>> _mockloggerSwapiModelBuilder;
        private SwapiModelBuilder _swapiModelBuilder;

        [TestInitialize]
        public void Init()
        {
            _mockISwapiServices = new Mock<ISwapiServices>();
            _mocklogger = new Mock<ILogger<SwapiController>>();
            _mockloggerSwapiModelBuilder = new Mock<ILogger<SwapiModelBuilder>>();
            _swapiModelBuilder = new SwapiModelBuilder(_mockISwapiServices.Object, _mockloggerSwapiModelBuilder.Object);
            _swapiController = new SwapiController(_mocklogger.Object, _swapiModelBuilder);
        }

        [TestMethod]
        public void GetStarshipForCharacter_With_Character_Failure()
        {
            Assert.AreEqual(true, GetStarshipForCharacter("Luke Skywaker"));
        }

        [TestMethod]
        public void GetStarshipForCharacter_Without_Character_Failure()
        {
            Assert.AreEqual(true, GetStarshipForCharacter(""));
        }

        private bool GetStarshipForCharacter(string name)
        {
            _mockISwapiServices.Setup(m => m.GetCharacterBiography<Character>(It.Is<string>(s => !string.IsNullOrEmpty(s)))).Returns(MockData.CharacterMockData.GetCharacterResponse());
            Task<Result> charactorRes = _swapiController.GetStarshipForCharacter(name);
            bool isResValid = charactorRes != null && charactorRes.Result != null && charactorRes.Result.result != null;
            return isResValid;
        }


    }
}
