using System;
using System.Threading.Tasks;

namespace CSharpIsFun.Features
{
    public static class LocalFunctions
    {
        public static Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

            async Task<string> longRunningWorkImplementation()
            {
                var interimResult = await FirstWork(address);
                var secondResult = await SecondStep(index, name);
                return $"The results are {interimResult} and {secondResult}. Enjoy.";

                Task<string> FirstWork(string a)
                {
                    return Task.FromResult(a.ToLowerInvariant());
                }
            }

            async Task<string> SecondStep(int i, string n)
            {
                return $"{i} - {n}";
            }
        }
    }
}