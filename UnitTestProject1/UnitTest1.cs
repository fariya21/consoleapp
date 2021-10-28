using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text;

namespace HelloWorldTests
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        private const string Expected = "Tests executed!fariya";
        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleApp1.Program.Main();
                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
                testContextInstance.WriteLine("test1 passed");
            }
        }

        [TestCleanup]
        public void WriteToLogFile()
        {
            var testOutcome = TestContext.CurrentTestOutcome;
            string testName = TestContext.TestName;

            StringBuilder sb = new StringBuilder();
            string str = testName + ": " + testOutcome.ToString() + "\n";
            sb.Append(str);
          
            File.AppendAllText("C:\\Results\\" + "log.txt", sb.ToString());
            sb.Clear();
        }
    }
}

