using PasswordHashGenerator.Shared.Interfaces;
using PasswordHashGenerator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashGenerator.Shared.Generators
{
    public class Sha1PasswordGenerator : IPasswordGenerator
    {
        public Sha1PasswordGenerator()
        {
        }

        public string Generate(GeneratorOptions options)
        {
            if (!IsHandling(options.Algorithm))
            {
                throw new ArgumentException($"Cannot handle algorithm {options.Algorithm}");
            }

            var sha1 = SHA1.Create();
            StringBuilder builder = new StringBuilder();
            builder.Append(options.MasterPassword);
            builder.Append(options.IgnoreIdentifierCase ? options.Identifier?.ToLowerInvariant() : options.Identifier);
            var hashedInput = Encoding.ASCII.GetBytes(builder.ToString());
            var computedHash = sha1.ComputeHash(hashedInput);
            var passwordHash = string.Join("", computedHash.Select(h => string.Format("{0:x2}", h)));
            return $"{options.Prefix}{passwordHash.Substring(0, options.PasswordLength)}{options.Postfix}";
        }

        public bool IsHandling(HashAlgorithmType algorithmType)
        {
            return algorithmType == HashAlgorithmType.Sha1;
        }
    }
}