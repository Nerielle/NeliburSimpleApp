using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class XUnitSimpleTests
    {
        [Fact]
        public void PositiveTest()
        {
            Assert.Equal(7, Add(3,4));
        }

        [Fact]
        public void NegativeTest()
        {
            Assert.Equal(5, Add(3,4));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
    }
}
