using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpIsFun.Features
{
    public static class PatternMatching
    {
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
    }
}