using System;

namespace CSharpIsFun.Features
{
    public class DefaultLiteralExpression
    {
        public Func<string, bool> whereClause1 = default(Func<string, bool>);

        public Func<string, bool> whereClause2 = default;

        public static Func<string, bool> GetFunc1()
        {
            return default(Func<string, bool>); ;
        }

        public static Func<string, bool> GetFunc2()
        {
            return default;
        }
    }
}