using PasswordHashGenerator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashGenerator.Shared.Interfaces
{
    public interface IPasswordGenerator
    {
        public bool IsHandling(HashAlgorithmType algorithmType);

        public string Generate(GeneratorOptions options);
    }
}