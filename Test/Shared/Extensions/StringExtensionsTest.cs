using PasswordHashGenerator.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordHashGenerator.Test.Shared.Extensions
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("a", false)]
        [InlineData(" ", false)]
        public void IsNullOrEmptyTest(string input, bool expected)
        {
            Assert.Equal(expected, input.IsNullOrEmpty());
        }
    }
}