using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Film
    {
        public string Name { get; set; }

        public int RunningTime { get; set; }

        public Film()
        {
        }

        public Film(string name, int runningTime)
        {
            Name = name;
            RunningTime = runningTime;
        }
    }
}
