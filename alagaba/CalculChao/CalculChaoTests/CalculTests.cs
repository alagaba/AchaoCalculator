using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculChao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculChao.Tests
{
    [TestClass()]
    public class CalculTests
    {
        [TestMethod()]
        public void ComputeTest()
        {
            String ans = Calcul.Compute("7*5+4");
            Assert.IsTrue(ans == 39.ToString());

        }
    }
}