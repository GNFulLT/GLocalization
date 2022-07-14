using GLocalization.Conceretes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLocalization.Tests
{
    internal class JSONTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitTest()
        {
            DefaultLocalizationManager.Init("GLocalization.Tests.Resources.English.locale.json");
            Assert.Pass();
        }
    }
}
