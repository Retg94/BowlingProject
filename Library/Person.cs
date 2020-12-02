using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Person
    {
        public Person(string name, int totalPoints = 0)
        {
            Name = name;
            TotalPoints = totalPoints;
            List<Points> framePoints = new List<Points>();
            FramePoints = framePoints;
        }
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public List<Points> FramePoints { get; set; }
    }
}
