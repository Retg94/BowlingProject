using System;
using System.Collections.Generic;

namespace Library
{
    public class Round
    {
        private List<Points> framePoints = new List<Points>();
        public int Roll(int ballOne, int ballTwo)
        {
            int totalPins = ballOne + ballTwo;
            if (totalPins > 10 || totalPins < 0 || ballOne < 0 || ballOne > 10 || ballTwo < 0 || ballTwo > 10)
                throw new ArgumentException();

            int tmpFramePoint = totalPins;
            if (ballOne == 10)
            {
                framePoints.Add(new Points(ballOne, ballTwo, tmpFramePoint, 'X'));
            }
            else if (ballOne + ballTwo == 10)
            {
                framePoints.Add(new Points(ballOne, ballTwo, tmpFramePoint, '/'));
            }
            else
                framePoints.Add(new Points(ballOne, ballTwo, tmpFramePoint));
            return tmpFramePoint;
        }
        public int Score()
        {
            int totalScore = 0;
            int framePoint = 0;            
            int previousScore = 0;
            for(int i = 0; i<framePoints.Count; i++)
            {
                if(i<10)
                {
                    framePoint = framePoints[i].Point;
                    if(framePoints[i].SpareOrStrike == 'X')
                    {
                        framePoint += framePoints[i + 1].BallOne;
                        if (framePoints[i + 1].SpareOrStrike == 'X')
                            framePoint += framePoints[i + 2].BallOne;
                        else
                            framePoint += framePoints[i + 1].BallTwo;
                    }
                    else if (framePoints[i].SpareOrStrike == '/')
                    {
                        framePoint += framePoints[i + 1].BallOne;
                    }
                    totalScore += framePoint;

                }
            }
            return totalScore;
        }
    }
}
