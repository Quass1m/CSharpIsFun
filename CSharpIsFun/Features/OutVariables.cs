using System;

namespace CSharpIsFun.Features
{
    public static class OutVariables
    {
        public static int GetOutVariableFromTryParse(string input)
        {
            if (int.TryParse(input, out var result))
                return result;
            else
                throw new ArgumentException(nameof(input));
        }
    }
}