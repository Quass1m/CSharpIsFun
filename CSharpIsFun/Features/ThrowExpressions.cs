using System;

namespace CSharpIsFun.Features
{
    public static class ThrowExpressions
    {
        public static string ThrowExpression(string value)
        {
            return value ?? throw new ArgumentException(nameof(value));
        }

        public static string NotImplementedProperty =>
            throw new NotImplementedException();
    }
}