using PasswordHashGenerator.Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordHashGenerator.Test.Shared.Security
{
    public class Crc32GeneratorTest
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(" ", 419)]
        [InlineData("crc32", 789)]
        public void GenerateTest(string input, int? expected)
        {
            Assert.Equal(Crc32Generator.Generate(input), expected);
        }
    }
}