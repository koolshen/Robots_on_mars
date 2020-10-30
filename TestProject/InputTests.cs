using IoC;
using NUnit.Framework;
using Robots_on_mars.Services.Interfaces;

namespace TestProject
{
    public class InputTests : TestBase
    {
        [Test]
        public void StringInputTest()
        {
            var input = new string[]{
                "5 3","1 1 E","RFRFRFRF","3 2 N","FRRFLLFFRRFLL","03 W","LLFFFLFLFL"
                };
            var result = inputService.GetInputData(input);
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void BadStringInputTest()
        {
            var input = new string[]{ "","1 1","RFRFRFRF","3 2 N","FRRFLLFFRRFLL","03 W","LLFFFLFLFL" };
            var result = inputService.GetInputData(input);
            Assert.IsTrue(!result.IsValid);
        }
    }
}