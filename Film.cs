using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Film
    {
        public string Name { get; private set; }

        public int RunningTime { get; private set; }

        public Film(string name, int runningTime)
        {
            Name = name;
            RunningTime = runningTime;
        }
    }
}
