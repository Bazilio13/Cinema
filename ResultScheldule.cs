using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class ResultScheldule
    {
        public List<Film> Scheldule { get; set; }
        public List<Film> Films { get; private set; }

        public int RemainingWorkingTime { get; set; }

        public ResultScheldule(List<Film> scheldule, int remainingWorkingTime)
        {
            Scheldule = scheldule;

            RemainingWorkingTime = remainingWorkingTime;

            Films = new List<Film>();

            foreach (Film film in Scheldule)
            {
                if (!Films.Contains(film))
                {
                    Films.Add(film);
                }
            }
        }

        public override string ToString()
        {
            DateTime startTime = DateTime.Today;
            startTime = startTime.AddHours(10);
            DateTime endTime = startTime;
            string result = "Расписание кинотеатра:";
            //string result = startTime.ToShortTimeString();
            foreach (Film film in Scheldule)
            {
                endTime = endTime.AddMinutes(film.RunningTime);
                result += $"\n{startTime.ToShortTimeString()} - {endTime.ToShortTimeString()} {film.Name}";
                startTime = endTime;
            }
            return result;
        }
    }
}
