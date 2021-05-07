using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class ResultCombinationOfScheldules
    {
        private List<ResultScheldule> _scheldules;
        public List<ResultScheldule> Scheldules
        {
            get
            {
                return _scheldules;
            }
            set
            {
                _scheldules = value;
                UniqFilmsInScheldules = GetUniqFilms(Scheldules);
                UnusedWorkingTime = 0;
                foreach (ResultScheldule scheldule in Scheldules)
                {
                    UnusedWorkingTime += scheldule.RemainingWorkingTime;
                }
            }
        }

        public List<Film> UniqFilmsInScheldules { get; private set; }

        public int UnusedWorkingTime { get; private set; }
        public ResultCombinationOfScheldules()

        {
            Scheldules = new List<ResultScheldule>();
        }

        public List<Film> GetUniqFilms(List<ResultScheldule> resultScheldules)
        {
            List<Film> films = new List<Film>();
            foreach (ResultScheldule scheldule in resultScheldules)
            {
                foreach (Film film in scheldule.UniqFilms)
                {
                    if (!films.Contains(film))
                    {
                        films.Add(film);
                    }
                }
            }
            return films;
        }

        public ResultCombinationOfScheldules Copy()
        {
            ResultCombinationOfScheldules copy = new ResultCombinationOfScheldules();
            List < ResultScheldule > copyResultScheldules = new List<ResultScheldule>();
            foreach (ResultScheldule scheldule in Scheldules)
            {
                copyResultScheldules.Add(scheldule);
            }
            copy.Scheldules = copyResultScheldules;
            return copy;
        }
    }
}
