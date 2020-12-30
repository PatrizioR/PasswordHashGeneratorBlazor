using PasswordHashGenerator.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Force.Crc32;

namespace PasswordHashGenerator.Shared.Security
{
    public static class Crc32Generator
    {
        public static int? Generate(string input, uint mod = 999)
        {
            if (input.IsNullOrEmpty())
            {
                return null;
            }
            return (int)(Crc32Algorithm.Compute(Encoding.ASCII.GetBytes(input)) % mod);
        }
    }
}