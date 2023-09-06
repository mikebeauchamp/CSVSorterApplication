using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace CSVSorter.Test
{
    public class Tests
    {
        
        [Test]        
        public void TestOneArgumentErrorMessage()
        {
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "argument1"});
            });

            Assert.AreEqual("This application must be given exactly three parameters: \n - the full file path of the CSV file (ex. C:\\temp\\test.csv) \n - the type of sorted values to be returned (alpha, numeric, both) \n - the sort order (ascending or descending)\r\n", capturedStdOut);
        }

        [Test]
        public void TestMissingFirstArgumentErrorMessage()
        {
            //test3.csv does not exist in C:\Temp\
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "", "both", "descending"});
            });

            Assert.AreEqual("\nPlease check your first parameter. File doesn't exist.\r\n", capturedStdOut);
        }

        [Test]
        public void TestMissingSecondArgumentErrorMessage()
        {
            //test2.csv exists in C:\Temp\
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test2.csv", "", "descending" });
            });

            Assert.AreEqual("\nPlease check your second parameter. The value second parameter must either be \"alpha\", \"numeric\" or \"both\".\r\n", capturedStdOut);
        }

        [Test]
        public void TestMissingThirdArgumentErrorMessage()
        {
            //test2.csv exists in C:\Temp\
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test2.csv", "alpha", "" });
            });

            Assert.AreEqual("\nPlease check your third parameter. The value third parameter must either be \"ascending\" or \"descending\".\r\n", capturedStdOut);
        }


        [Test]
        public void TestNumericCSVValuesAscending()
        {
            //test.csv in located in C:\Temp and contains the following values: 1,4,6,7,3,2,1.5
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test.csv", "numeric", "ascending" });
            });

            Assert.AreEqual("1, 1.5, 2, 3, 4, 6, 7\r\n", capturedStdOut);
        }

        [Test]
        public void TestNumericCSVValuesDescending()
        {
            //test.csv in located in C:\Temp and contains the following numeric values: 1,4,6,7,3,2,1.5
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test.csv", "numeric", "descending" });
            });

            Assert.AreEqual("7, 6, 4, 3, 2, 1.5, 1\r\n", capturedStdOut);
        }

        [Test]
        public void TestAlphaNumericCSVValuesNumericAscending()
        {
            //test2.csv in located in C:\Temp and contains both the following numeric and alpha values: 11,12,1e10,'c',b,'a',15,21,'50'
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test2.csv", "numeric", "ascending" });
            });

            Assert.AreEqual("11, 12, 15, 21, 1e10\r\n", capturedStdOut);
        }

        [Test]
        public void TestAlphaNumericCSVValuesAlphaAscending()
        {
            //test2.csv in located in C:\Temp and contains both the following numeric and alpha values: 11,12,1e10,'c',b,'a',15,21,'50'
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test2.csv", "alpha", "ascending" });
            });

            Assert.AreEqual("'50', 'a', b, 'c'\r\n", capturedStdOut);
        }

        [Test]
        public void TestAlphaNumericCSVValuesBothAscending()
        {
            //test2.csv in located in C:\Temp and contains both the following numeric and alpha values: 11,12,1e10,'c',b,'a',15,21,'50'
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test2.csv", "both", "ascending" });
            });

            Assert.AreEqual("11, 12, 15, 21, 1e10, '50', 'a', b, 'c'\r\n", capturedStdOut);
        }

        [Test]
        public void TestAlphaNumericCSVValuesBothDescending()
        {
            //test2.csv in located in C:\Temp and contains both the following numeric and alpha values: 11,12,1e10,'c',b,'a',15,21,'50'
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "C:\\Temp\\test2.csv", "both", "descending" });
            });

            Assert.AreEqual("'c', b, 'a', '50', 1e10, 21, 15, 12, 11\r\n", capturedStdOut);
        }

        void RunApp(string[]? arguments = default)
        {
            var entryPoint = typeof(Program).Assembly.EntryPoint!;
            entryPoint.Invoke(null, new object[] { arguments ?? Array.Empty<string>() });
        }

        string CapturedStdOut(Action callback)
        {
            TextWriter originalStdOut = Console.Out;

            using var newStdOut = new StringWriter();
            Console.SetOut(newStdOut);

            callback.Invoke();
            var capturedOutput = newStdOut.ToString();

            Console.SetOut(originalStdOut);

            return capturedOutput;
        }
    }
}