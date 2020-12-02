using System;
using Xunit;
using Library;
using System.Collections.Generic;

namespace BowlingProject.UnitTest
{
    public class BowlingProjectTests
    {
        public Person CreatePlayer(string name)
        {
            Person person = new Person(name);
            return person;
        }
        public void CreatePlayerAndAddToList(string name)
        {
            HandlePersonPoints.AddPlayerToList(name);
        }
        [Fact]
        public void ReturnFramePoint_Roll2and2_Return4()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int actual = Round.Roll(2, 2, Player);

            Assert.Equal(4, actual);
        }
        [Fact]
        public void ReturnFramePoint_Roll0and0_Return0()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int actual = Round.Roll(0, 0, Player);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void ReturnFramePoint_BallOneMinusValue_ThrowArgumentException()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            Assert.Throws<ArgumentException>(() => Round.Roll(-2, 2, Player));
        }

        [Fact]
        public void ReturnFramePoint_BallTwoMinusValue_ThrowArgumentException()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            Assert.Throws<ArgumentException>(() => Round.Roll(2, -2, Player));
        }

        [Fact]
        public void ReturnFramePoint_RollMoreThan10_ThrowArgumentException()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            Assert.Throws<ArgumentException>(() => Round.Roll(9, 2, Player));
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyZeroes_Return0()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(0, 0, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(0, Player.TotalPoints);
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyOnes_Return10()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(1, 0, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(10, Player.TotalPoints);
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyStrikes_Return300()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 12; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(300, Player.TotalPoints);
        }
        [Fact]
        public void ReturnTotalScore_RollOnly5And5_Return150()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 11; i++)
            {
                currentScore = Round.Roll(5, 5, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(150, Player.TotalPoints);
        }
        [Fact]
        public void AddNewPlayer_ReturnPlayerName()
        {
            Person person = new Person("Richard");

            Assert.Equal("Richard", person.Name);
        }
        [Fact]
        public void ReturnTotalScore_Roll10StrikesAndTwoOnesAsBonusThrows_Return273()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            Round.Roll(1, 1, Player);

            int totalScore = Round.Score(Player);

            Assert.Equal(273, Player.TotalPoints);
        }
        [Fact]
        public void ReturnTotalScore_Roll10StrikesAndOneStrikeAndOneAsBonus_Return291()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 11; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            Round.Roll(1, 0, Player);

            int totalScore = Round.Score(Player);

            Assert.Equal(291, Player.TotalPoints);
        }
        [Fact]
        public void ReturnTotalScore_Roll9StrikesAndTwoFivesAndOneOneAsBonus_Return273()
        {
            var Round = new Round();
            Person Player = CreatePlayer("Richard");

            int currentScore = 0;
            for (int i = 0; i < 9; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            Round.Roll(5, 5, Player);
            Round.Roll(1, 0, Player);
            int totalScore = Round.Score(Player);

            Assert.Equal(266, Player.TotalPoints);
        }
        [Fact]
        public void ActivePlayers_CreateFourPlayersAndRoll()
        {
            var Round = new Round(); 
            Person person1 = CreatePlayer("Erik");
            Person person2 = CreatePlayer("Runar");
            Person person3 = CreatePlayer("Mats");
            Person person4 = CreatePlayer("Bosse");
            List<Person> Players = new List<Person>();
            Players.Add(person1);
            Players.Add(person2);
            Players.Add(person3);
            Players.Add(person4);
            int index = 0;
            //Detta känns som en dum testning
            foreach(var player in Players)
            {
                Round.Roll(1, 1, player);
                if(index == 0)
                {
                    Assert.Equal("Erik", player.Name);
                }
                if (index == 1)
                {
                    Assert.Equal("Runar", player.Name);
                }
                if (index == 2)
                {
                    Assert.Equal("Mats", player.Name);
                }
                if (index == 3)
                {
                    Assert.Equal("Bosse", player.Name);
                }
                index++;
            }

        }

    }
}
