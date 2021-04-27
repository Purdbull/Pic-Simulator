using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class DecodeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ushort testData = Convert.ToUInt16("0000", 16);
            Pic_Simulator.CodeExecution.Decode(testData);
        }
    }
}
