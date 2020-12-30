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
            PasswordLength = 12;
            Postfix = "!P";
            Algorithm = HashAlgorithmType.Sha1;
            IgnoreIdentifierCase = true;
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
    }
}