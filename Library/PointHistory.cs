using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PointHistory
    {
        public PointHistory(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
