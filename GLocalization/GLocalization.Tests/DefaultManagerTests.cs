using NUnit.Framework;
using GLocalization.Conceretes;
namespace GLocalization.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitTest()
        {
            DefaultLocalizationManager.Init("fake");
            Assert.Pass();
        }
    }
}