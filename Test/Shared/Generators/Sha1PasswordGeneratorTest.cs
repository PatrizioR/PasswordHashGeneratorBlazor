using PasswordHashGenerator.Shared.Generators;
using PasswordHashGenerator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordHashGenerator.Test.Shared.Generators
{
    public class Sha1PasswordGeneratorTest
    {
        public Sha1PasswordGenerator generator { get; set; }

        public Sha1PasswordGeneratorTest()
        {
            generator = new Sha1PasswordGenerator();
        }

        [Theory]
        [InlineData(HashAlgorithmType.Sha1, true)]
        [InlineData(HashAlgorithmType.Md5, false)]
        [InlineData(HashAlgorithmType.Sha256, false)]
        [InlineData(HashAlgorithmType.Sha384, false)]
        [InlineData(HashAlgorithmType.Sha512, false)]
        [InlineData(HashAlgorithmType.None, false)]
        public void IsHandlingTest(HashAlgorithmType algorithmType, bool expected)
        {
            Assert.Equal(expected, generator.IsHandling(algorithmType));
        }

        [Theory]
        [InlineData("identifier", "masterpassword", 0, "prefix", "postfix", "prefixpostfix")]
        [InlineData("identifier", "masterpassword", 12, "prefix", "postfix", "prefix510f61dbdde5postfix")]
        [InlineData(" ", " ", 12, null, "postfix", "099600a10a94postfix")]
        [InlineData(" ", " ", 12, null, null, "099600a10a94")]
        [InlineData(" ", " ", 12, "prefix", null, "prefix099600a10a94")]
        [InlineData(" ", " ", 12, "prefix", "postfix", "prefix099600a10a94postfix")]
        public void GenerateTest(string identifier, string masterpassword, int length, string prefix, string postfix, string expected)
        {
            var options = new GeneratorOptions
            {
                Identifier = identifier,
                MasterPassword = masterpassword,
                PasswordLength = length,
                Algorithm = HashAlgorithmType.Sha1,
                Prefix = prefix,
                Postfix = postfix
            };
            Assert.Equal(expected, generator.Generate(options));
        }
    }
}