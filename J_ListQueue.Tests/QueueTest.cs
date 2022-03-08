using System;
using System.IO;
using Xunit;

namespace J_ListQueue.Tests
{
    public class QueueTest

    {
        //[Theory]
        //[MemberData(nameof(ExternalCorrectnessTestData.TestData), MemberType = typeof(ExternalCorrectnessTestData))]
        [Fact]
        public void MustBeCorrect()
        {
            var output = new StringWriter();
            var input = new StringReader("1\n1\n1\n1\n1\n1\n1\n1\n");

            Console.SetOut(output);
            Console.SetIn(input);


            Solution.Main(new string[0]);


            var outputString = output.ToString();

            Assert.Equal("", outputString);
        }
    }
}
