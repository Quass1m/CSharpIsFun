using FluentAssertions;
using System;
using Xunit;

namespace CSharpIsFunTests
{
    public class EqualityTests
    {
        [Fact]
        public void Test1()
        {
            object o1 = null;
            object o2 = new object();

            //Technically, these should read object.ReferenceEquals for clarity, but this is redundant.
            ReferenceEquals(o1, o1).Should().BeTrue();
            ReferenceEquals(o1, o2).Should().BeFalse();
            ReferenceEquals(o2, o1).Should().BeFalse();
            ReferenceEquals(o2, o2).Should().BeTrue();

            Action res1 = (() => { o1.Equals(o1); });
            res1.Should().Throw<NullReferenceException>();
            Action res2 = (() => { o1.Equals(o2); });
            res2.Should().Throw<NullReferenceException>();
            o2.Equals(o1).Should().BeFalse();
            o2.Equals(o2).Should().BeTrue();

            o2.Equals(new object()).Should().BeFalse();
            (o1 == o2).Should().BeFalse();

            object o1prim = o1;
            object o2prim = o2;

            ReferenceEquals(o1, o1prim).Should().BeTrue();
            ReferenceEquals(o1prim, o2prim).Should().BeFalse();
            ReferenceEquals(o2prim, o1prim).Should().BeFalse();
            ReferenceEquals(o2, o2prim).Should().BeTrue();

            (o1 == o1prim).Should().BeTrue();
            (o2 == o2prim).Should().BeTrue();
        }

        [Fact]
        public void Test2()
        {
            int int1 = 3;
            // value type boxing occurs
            ReferenceEquals(int1, int1).Should().BeFalse();
            int1.GetType().IsValueType.Should().BeTrue();

            int1.Equals(int1).Should().BeTrue();
            int1.Equals(1).Should().BeFalse();
        }
    }
}
