using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Points
    {
        public Points(int ballOne, int ballTwo, int point, char spareOrStrike)
        {
            BallOne = ballOne;
            BallTwo = ballTwo;
            Point = point;
            SpareOrStrike = spareOrStrike;
        }
        public int BallOne { get; set; }
        public int BallTwo { get; set; }
        public int Point { get; set; }
        public char SpareOrStrike { get; set; }
    }
}
