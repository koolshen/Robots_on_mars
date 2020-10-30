using Entities.Enums;
using IoC;
using NUnit.Framework;
using Robots_on_mars.Services.Interfaces;
using System.Linq;

namespace TestProject
{
    public class RobotTests : TestBase
    {

        [Test]
        public void MainCaseRobotsMovementTest()
        {
            var input = new string[]{ "5 3","1 1 E", "RFRFRFRF", "3 2 N","FRRFLLFFRRFLL","0 3 W","LLFFFLFLFL" };
            var result = inputService.GetInputData(input);

            foreach (var robotItem in result.Robots)
            {
                instructionService.ExecuteInstructions(robotItem, result);
            }

            Assert.AreEqual(result.Robots.ElementAt(0).ToString(), "1 1 E");
            Assert.AreEqual(result.Robots.ElementAt(1).ToString(), "3 3 N LOST");
            Assert.AreEqual(result.Robots.ElementAt(2).ToString(), "2 3 S");

        }

        [Test]
        public void InputWithoutWhitespacesTest()
        {
            var input = new string[] { "53", "11E", "RFRFRFRF", "32N", "FRRFLLFFRRFLL", "03W", "LLFFFLFLFL" };
            var result = inputService.GetInputData(input);

            foreach (var robotItem in result.Robots)
            {
                instructionService.ExecuteInstructions(robotItem, result);
            }

            Assert.AreEqual(result.Robots.ElementAt(0).ToString(), "1 1 E");
            Assert.AreEqual(result.Robots.ElementAt(1).ToString(), "3 3 N LOST");
            Assert.AreEqual(result.Robots.ElementAt(2).ToString(), "2 3 S");

        }

        [Test]
        public void InputWithLowercasesTest()
        {
            var input = new string[] { "53", "11e", "rfrfrfrf", "32n", "FRRFLLFFRRFLL", "03w", "llFFFLFlfl" };
            var result = inputService.GetInputData(input);

            foreach (var robotItem in result.Robots)
            {
                instructionService.ExecuteInstructions(robotItem, result);
            }

            Assert.AreEqual(result.Robots.ElementAt(0).ToString(), "1 1 E");
            Assert.AreEqual(result.Robots.ElementAt(1).ToString(), "3 3 N LOST");
            Assert.AreEqual(result.Robots.ElementAt(2).ToString(), "2 3 S");

        }

    }
}