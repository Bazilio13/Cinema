using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class ResultCombinationOfScheldules
    {
        public List<ResultScheldule> Scheldules { get; set; }
        //{
        //    get
        //    {
        //        return _scheldules;
        //    }
        //    set
        //    {
        //        _scheldules = value;
        //        CountUniqFilms();
        //        UnusedWorkingTime = 0;
        //        foreach (ResultScheldule scheldule in Scheldules)
        //        {
        //            UnusedWorkingTime += scheldule.RemainingWorkingTime;
        //        }
        //    }
        //}

        public Dictionary<Film, int> UniqFilmsInScheldules { get; private set; }

        public int MinCountOfSessions { get; private set; }

        public int UnusedWorkingTime { get; private set; }
        public ResultCombinationOfScheldules()

        {
            Scheldules = new List<ResultScheldule>();
            UniqFilmsInScheldules = new Dictionary<Film, int>();
        }

        public void UpdFields()
        {
            UnusedWorkingTime = 0;
            foreach (ResultScheldule scheldule in Scheldules)
            {
                foreach (Film film in scheldule.Scheldule)
                {
                    if (!UniqFilmsInScheldules.TryAdd(film, 1))
                    {
                        UniqFilmsInScheldules[film] += 1;
                    }
                    MinCountOfSessions++;
                }
                UnusedWorkingTime += scheldule.RemainingWorkingTime;
            }
            if (UniqFilmsInScheldules.Count != 0)
            {
                foreach (int countOfSessions in UniqFilmsInScheldules.Values)
                {
                    if (countOfSessions < MinCountOfSessions) MinCountOfSessions = countOfSessions;
                }
            }
        }

        public ResultCombinationOfScheldules Copy()
        {
            ResultCombinationOfScheldules copy = new ResultCombinationOfScheldules();
            List<ResultScheldule> copyResultScheldules = new List<ResultScheldule>();
            foreach (ResultScheldule scheldule in Scheldules)
            {
                copyResultScheldules.Add(scheldule);
            }
            copy.Scheldules = copyResultScheldules;
            foreach (Film film in UniqFilmsInScheldules.Keys)
            {
                copy.UniqFilmsInScheldules.Add(film, UniqFilmsInScheldules[film]);
            }
            copy.MinCountOfSessions = MinCountOfSessions;
            copy.UnusedWorkingTime = UnusedWorkingTime;
            return copy;
        }
    }
}
