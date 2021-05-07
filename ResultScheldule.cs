using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class ResultScheldule
    {
        public List<Film> Scheldule { get; set; }
        public List<Film> UniqFilms { get; private set; }

        public int RemainingWorkingTime { get; set; }

        public ResultScheldule(List<Film> scheldule, int remainingWorkingTime)
        {
            Scheldule = scheldule;

            RemainingWorkingTime = remainingWorkingTime;

            UniqFilms = new List<Film>();

            GetUnqFilms();
        }

        public override string ToString()
        {
            DateTime startTime = DateTime.Today;
            startTime = startTime.AddHours(10);
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

        //public ResultScheldule Copy ()
        //{
        //    List<Film> schelduleCopy = new List<Film>();
        //    foreach (Film film in Scheldule)
        //    {
        //        schelduleCopy.Add(film);
        //    }
        //    ResultScheldule copy = new ResultScheldule(schelduleCopy, RemainingWorkingTime);
        //    return copy;
        //}

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
