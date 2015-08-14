using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class XUnitSimpleTests
    {
        private readonly ITestOutputHelper output;

        public XUnitSimpleTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> TestData => new[]
        {
            new object[]
            {
                new Range[]
                {
                    new Range(1, 5),
                    new Range(0,7 )
                }
            }
        };

        [Fact]
        public void PositiveTest()
        {
            var comment = "Positive test";
            output.WriteLine(comment);
            Assert.Equal(7, Add(3, 4));
        }

        [Fact]
        public void NegativeTest()
        {
            Assert.Equal(5, Add(3, 4));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }

       

        [Theory]
        [MemberData("TestData")]
        public void RangeContainsValue_ShouldContains(IEnumerable<Range> ranges)
        {
            int value = 5;
            ranges.ToList().ForEach(r=>
            Assert.True(r.RangeContainsValue(value)));
        }

        public struct Range
        {
            public Range(int left, int right)
            {
                Left = left;
                Right = right;
            }

            private int Left { get; set; }
            private int Right { get; set; }
            internal bool RangeContainsValue(int value)
            {
                return Left <= value && value <= Right;
            }
        }
    }
}
