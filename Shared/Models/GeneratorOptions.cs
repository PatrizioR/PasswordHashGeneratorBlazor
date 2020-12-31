using PasswordHashGenerator.Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashGenerator.Shared.Models
{
    public class GeneratorOptions
    {
        public GeneratorOptions()
        {
        }

        public string MasterPassword { get; set; }
        public int? MasterPasswordCrc32 => Crc32Generator.Generate(MasterPassword);
        public string Identifier { get; set; }
        public string Password { get; set; }
        public int PasswordLength { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public bool IgnoreIdentifierCase { get; set; }
        public HashAlgorithmType Algorithm { get; set; }

        public GeneratorOptions CleanCopy()
        {
            return new GeneratorOptions()
            {
                PasswordLength = PasswordLength,
                Prefix = Prefix,
                Postfix = Postfix,
                IgnoreIdentifierCase = IgnoreIdentifierCase,
                Algorithm = Algorithm
            };
        }
    }
}