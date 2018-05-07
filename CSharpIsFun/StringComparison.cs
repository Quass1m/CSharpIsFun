using System;
using System.Collections.Generic;

namespace CSharpIsFun
{
    public class StringComparison
    {
        private List<string> a;
        private List<string> b;

        public StringComparison(List<string> a, List<string> b)
        {
            this.a = a;
            this.b = b;

            if (a.Count != b.Count)
                throw new ArgumentException("The lists should be equal in length");
        }

        public void CompareLowercase()
        {
            for (int i = 0; i < a.Count; i++)
            {
                var _ = a[i].ToLower() == b[i].ToLower();
            }
        }

        public void CompareUppercase()
        {
            for (int i = 0; i < a.Count; i++)
            {
                var _ = a[i].ToUpper() == b[i].ToUpper();
            }
        }

        public void CompareStringEquals()
        {
            for (int i = 0; i < a.Count; i++)
            {
                var _ = string.Equals(a[i], b[i], System.StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }
}