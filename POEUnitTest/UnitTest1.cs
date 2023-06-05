using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace POEUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddCalories()
        {
                double t = 0;
                for (int i = 0; i < ingrCal.Count; i++)
                {
                    t = ingrCal[i] + t;
                }

                return t;
        }
    }
}
