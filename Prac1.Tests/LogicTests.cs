using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Prac1.Tests
{
    [TestFixture]
    public class LogicTests
    {
        private Logic _logic;

        [SetUp]
        public void Setup()
        {
            _logic = new Logic();
        }

        [Test]
        public void TestReadFromFile1()
        {
            const string fileName = "test_files/TestReadFromFile1.txt";
            const string expectedRes = "";
            var res = _logic.ReadFromFile(fileName);
            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestReadFromFile2()
        {
            const string fileName = "test_files/TestReadFromFile2.txt";
            const string expectedRes = "abc def абв гд[]-()*0123456789 `~Ё";
            var res = _logic.ReadFromFile(fileName);
            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestReadFromFile3()
        {
            const string fileName = "test_files/TestReadFromFile3.txt";
            const string expectedRes = "abc\r\nабв\r\n";
            var res = _logic.ReadFromFile(fileName);
            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestFilter1()
        {
            const string text = "abc\na\nабвыэ12";
            var expectedRes = new List<string>() {"abc", "a"};
            var res = _logic.Filter(text, 7);
            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestFilter2()
        {
            const string text = "abc\na\nабвыэ12";
            var expectedRes = new List<string>() { "a" };
            var res = _logic.Filter(text, 2);
            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestFilter3()
        {
            const string text = "abc\na\nабвыэ12\n[]{}zxcv";
            var expectedRes = new List<string>();
            var res = _logic.Filter(text, 0);
            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestWriteToFile1()
        {
            const string fileName = "TestWriteToFile1.txt";
            var list = new List<string>() { "abc", "a", "абв123" };
            const string expectedRes = "abc\na\nабв123\n";

            _logic.WriteToFile(list, fileName);

            string res;
            using (var sr = new StreamReader(fileName))
            {
                res = sr.ReadToEnd();
            }

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestWriteToFile2()
        {
            const string fileName = "TestWriteToFile2.txt";
            var list = new List<string>() { "<>[]{siop}юбжэ`T", "", "\n" };
            const string expectedRes = "<>[]{siop}юбжэ`T\n\n\n\n";

            _logic.WriteToFile(list, fileName);

            string res;
            using (var sr = new StreamReader(fileName))
            {
                res = sr.ReadToEnd();
            }

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void TestWriteToFile3()
        {
            const string fileName = "TestWriteToFile3.txt";
            var list = new List<string>() { "качество"};
            const string expectedRes = "качество\n";

            _logic.WriteToFile(list, fileName);

            string res;
            using (var sr = new StreamReader(fileName))
            {
                res = sr.ReadToEnd();
            }

            Assert.AreEqual(expectedRes, res);
        }
    }
}