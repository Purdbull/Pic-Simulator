using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class MemoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Pic_Simulator.ProgramMemory progMem = new Pic_Simulator.ProgramMemory();
            progMem.GetKeyValuePair(5);
        }
    }
}