using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangFeatures70.LangFeatures
{
    /// <summary>
    /// C# 7.0
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7"/>
    public class Version70
    {
        #region OutVariales
        public static int OutVariables(string input)
        {
            if (int.TryParse(input, out var result))
                return result;
            else
                throw new ArgumentException(nameof(input));
        }
        #endregion

        #region Tuples
        public static (string s, int i) Tuples1(string inputString, int intputInt)
        {
            return (inputString, intputInt);
        }

        public static (string First, int Second) Tuples2(string inputString, int intputInt)
        {
            return (First: inputString, Second: intputInt);
        }
        #endregion

        #region Discards
        public static int Discards(IEnumerable<int> numbers)
        {
            // Return only max value
            var (max, _) = Range(numbers);

            return max;
        }

        private static (int Max, int Min) Range(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }

            return (max, min);
        }
        #endregion

        #region PatternMatching
        public static int DiceSum5(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case PercentileDice dice:
                        sum += dice.TensDigit + dice.OnesDigit;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSum5(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
            return sum;
        }

        private struct PercentileDice
        {
            public int OnesDigit { get; set; }
            public int TensDigit { get; set; }
        }
        #endregion

        #region Ref locals and returns
        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }
        #endregion

        #region Local functions
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
        #endregion

        #region Throw expression
        public static string ThrowExpression(string value)
        {
            return value ?? throw new ArgumentException(nameof(value));
        }

        public static string NotImplementedProperty =>
            throw new NotImplementedException();
        #endregion

        #region ValueType
        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }
        
        private bool cache = false;
        private int cacheResult;
        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
        #endregion

        #region Numeric literal syntax
        public const int One = 0b0001;
        public const int Two = 0b0010;
        public const int Four = 0b0100;
        public const int Eight = 0b1000;
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        public const long BillionsAndBillions = 100_000_000_000;
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        #endregion
    }
}
