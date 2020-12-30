using PasswordHashGenerator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashGenerator.Shared.Handlers
{
    public static class PasswordGeneratorHandler
    {
        public static IEnumerable<IPasswordGenerator> FindGenerators(HashAlgorithmType algorithmType)
        {
            var type = typeof(IPasswordGenerator);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);
            Console.WriteLine($"Count {types.Count()}");
            return types.Select(gen => Activator.CreateInstance(gen) as IPasswordGenerator).Where(gen => gen.IsHandling(algorithmType));
        }
    }
}