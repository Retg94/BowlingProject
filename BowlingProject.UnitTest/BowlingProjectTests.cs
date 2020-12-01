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
        public void ReturnFramePoint_Roll0and0_Return0()
        {
            var Round = new Round();

            int actual = Round.Roll(0, 0);

            Assert.Equal(0, actual);
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
        [Fact]
        public void ReturnTotalScore_RollOnlyZeroes_Return0()
        {
            var Round = new Round();
            int currentScore = 0;
            for(int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(0, 0);
            }
            int totalScore = Round.Score();

            Assert.Equal(0, totalScore);
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyOnes_Return10()
        {
            var Round = new Round();
            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(1, 0);
            }
            int totalScore = Round.Score();

            Assert.Equal(10, totalScore);
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyStrikes_Return300()
        {
            var Round = new Round();
            int currentScore = 0;
            for (int i = 0; i < 12; i++)
            {
                currentScore = Round.Roll(10, 0);
            }
            int totalScore = Round.Score();

            Assert.Equal(300, totalScore);
        }
        [Fact]
        public void ReturnTotalScore_RollOnly5And5_Return150()
        {
            var Round = new Round();
            int currentScore = 0;
            for (int i = 0; i < 11; i++)
            {
                currentScore = Round.Roll(5, 5);
            }
            int totalScore = Round.Score();

            Assert.Equal(150, totalScore);
        }
    }
}
