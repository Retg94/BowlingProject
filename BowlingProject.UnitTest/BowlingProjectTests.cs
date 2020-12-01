using System;
using Xunit;
using Library;

namespace BowlingProject.UnitTest
{
    public class BowlingProjectTests
    {
        [Fact]
        public void ReturnFramePoint_Roll2and2_Return4()
        {
            var Round = new Round();

            int actual = Round.Roll(2, 2);

            Assert.Equal(4, actual);
        }

        [Fact]
        public void ReturnFramePoint_BallOneMinusValue_ThrowArgumentException()
        {
            var Round = new Round();

            Assert.Throws<ArgumentException>(() => Round.Roll(-2, 2));
        }

        [Fact]
        public void ReturnFramePoint_BallTwoMinusValue_ThrowArgumentException()
        {
            var Round = new Round();

            Assert.Throws<ArgumentException>(() => Round.Roll(2, -2));
        }

        [Fact]
        public void ReturnFramePoint_RollMoreThan10_ThrowArgumentException()
        {
            var Round = new Round();

            Assert.Throws<ArgumentException>(() => Round.Roll(9, 2));
        }
    }
}
