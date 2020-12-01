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
    }
}
