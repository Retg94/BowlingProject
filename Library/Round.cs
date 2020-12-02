using System;
using System.Collections.Generic;


namespace Library
{
    public class Round
    {
        //private List<Points> framePoints = new List<Points>();
        public int Roll(int ballOne, int ballTwo, Person player)
        {
            int totalPins = ballOne + ballTwo;
            if (totalPins > 10 || totalPins < 0 || ballOne < 0 || ballOne > 10 || ballTwo < 0 || ballTwo > 10)
                throw new ArgumentException();

            int tmpFramePoint = totalPins;
            if (ballOne == 10)
            {
                player.FramePoints.Add(new Points(ballOne, ballTwo, tmpFramePoint, 'X'));
            }
            else if (ballOne + ballTwo == 10)
            {
                player.FramePoints.Add(new Points(ballOne, ballTwo, tmpFramePoint, '/'));
            }
            else
            {
                player.FramePoints.Add(new Points(ballOne, ballTwo, tmpFramePoint, '0'));
            }

            return tmpFramePoint;
        }
        public int Score(Person player)
        {
            int totalScore = 0;
            int framePoint = 0;            
            for(int i = 0; i<player.FramePoints.Count; i++)
            {
                if(i<10)
                {
                    framePoint = player.FramePoints[i].Point;
                    if(player.FramePoints[i].SpareOrStrike == 'X')
                    {
                        framePoint += player.FramePoints[i + 1].BallOne;
                        if (player.FramePoints[i + 1].SpareOrStrike == 'X')
                            framePoint += player.FramePoints[i + 2].BallOne;
                        else
                            framePoint += player.FramePoints[i + 1].BallTwo;
                    }
                    else if (player.FramePoints[i].SpareOrStrike == '/')
                    {
                        framePoint += player.FramePoints[i + 1].BallOne;
                    }
                    totalScore += framePoint;
                }
            }
            player.TotalPoints = totalScore;
            return totalScore;
        }
    }
}
