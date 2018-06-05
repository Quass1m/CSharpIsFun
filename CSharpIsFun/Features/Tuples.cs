namespace CSharpIsFun.Features
{
    public static class Tuples
    {
        public static (string s, int i) Tuples1(string inputString, int intputInt)
        {
            return (inputString, intputInt);
        }

        public static (string first, int second) Tuples2(string inputString, int intputInt)
        {
            return (first: inputString, second: intputInt);
        }

        public static string InferredNames()
        {
            var values = Tuples2("A", 5);

            return $"{values.first}_{values.second}";
        }

        public static (string first, int second, char third) Tuples3(string inputString, int intputInt, char inputChar)
        {
            return (first: inputString, second: intputInt, third: inputChar);
        }
    }
}