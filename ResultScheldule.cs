using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class ResultScheldule
    {
        public List<Film> Scheldule { get; set; }
        public List<Film> UniqFilms { get; private set; }

        public int StartHourOfWorking { get; set; }
        public int StartOfWorkingInMinutes { get; set; }

        public int RemainingWorkingTime { get; set; }

        public ResultScheldule(List<Film> scheldule, int remainingWorkingTime, int startOfWorkingInMinutes)
        {
            Scheldule = scheldule;

            RemainingWorkingTime = remainingWorkingTime;

            StartOfWorkingInMinutes = startOfWorkingInMinutes;

            UniqFilms = new List<Film>();

            GetUnqFilms();
        }

        public override string ToString()
        {
            DateTime startTime = DateTime.Today;
            startTime = startTime.AddMinutes(StartOfWorkingInMinutes);
            DateTime endTime = startTime;
            string result = "";
            foreach (Film film in Scheldule)
            {
                endTime = endTime.AddMinutes(film.RunningTime);
                result += $"{startTime.ToShortTimeString()} - {endTime.ToShortTimeString()} {film.Name}\n";
                startTime = endTime;
            }
            return result;
        }

        private void GetUnqFilms()
        {
            foreach (Film film in Scheldule)
            {
                if (!UniqFilms.Contains(film))
                {
                    UniqFilms.Add(film);
                }
            }
        }
    }
}
