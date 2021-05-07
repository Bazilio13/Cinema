using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Node
    {
        public List<Node> Next;

        public List<Film> CurrentSchedule;

        public List<Film> Films;

        public int RemainingWorkingTime;

        public Node(int workingTime, List<Film> fIlms, List<Film> currentSchedule = null)
        {
            RemainingWorkingTime = workingTime;

            Films = fIlms;

            if (!(currentSchedule is null))
            {
                CurrentSchedule = currentSchedule;
            }
            else
            {
                CurrentSchedule = new List<Film>();
            }

            Next = new List<Node>();
        }

        public void CreateGraph()
        {
            foreach (Film film in Films)
            {
                if (film.RunningTime <= RemainingWorkingTime)
                {
                    CurrentSchedule.Add(film);
                    List<Film> tmp = CopyFilmList(CurrentSchedule);
                    RemainingWorkingTime -= film.RunningTime;
                    Node next = new Node(RemainingWorkingTime, Films, tmp);
                    Next.Add(next);
                    next.CreateGraph();
                }
            }
        }

        public List<Film> CopyFilmList(List<Film> list)
        {
            List<Film> newList = new List<Film>();
            foreach (Film film in list)
            {
                newList.Add(film);
            }
            return newList;
        }

        public List<ResultScheldule> CopySchelduleList(List<ResultScheldule> list)
        {
            List<ResultScheldule> newList = new List<ResultScheldule>();
            foreach (ResultScheldule scheldule in list)
            {
                newList.Add(scheldule);
            }
            return newList;
        }

        public ResultScheldule GetOptimalScheldule()
        {
            if (Next.Count == 0)
            {
                return new ResultScheldule(CurrentSchedule, RemainingWorkingTime);
            }
            else
            {
                List<ResultScheldule> results = new List<ResultScheldule>();
                foreach (Node next in Next)
                {
                    results.Add(next.GetOptimalScheldule());
                }
                ResultScheldule optimalResult = results[0];
                for (int i = 1; i < results.Count; i++)
                {
                    if (optimalResult.UniqFilms.Count < results[i].UniqFilms.Count)
                    {
                        optimalResult = results[i];
                    }
                    else if (optimalResult.RemainingWorkingTime > results[i].RemainingWorkingTime)
                    {
                        optimalResult = results[i];
                    }
                }
                return optimalResult;
            }
        }

        public List<ResultScheldule> GetAllVariantsOfScheldule(List<ResultScheldule> results = null)
        {
            if (results is null)
            {
                results = new List<ResultScheldule>();
            }
            if (Next.Count == 0)
            {
                results.Add(new ResultScheldule(CurrentSchedule, RemainingWorkingTime));
            }
            else
            {
                foreach (Node next in Next)
                {
                    next.GetAllVariantsOfScheldule(results);
                }
            }
            return results;
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

        public ResultCombinationOfScheldules GetOptimalScheldules(int hallsCount, int hallNum = 0, List<ResultScheldule> allVariantsOfScheldules = null, ResultCombinationOfScheldules optimalScheldules = null)
        {
            if (allVariantsOfScheldules is null)
            {
                allVariantsOfScheldules = GetAllVariantsOfScheldule();
                optimalScheldules = new ResultCombinationOfScheldules();
                for (int i = 0; i < hallsCount; i++)
                {
                    int j = i;
                    if (i > allVariantsOfScheldules.Count)
                    {
                        j = allVariantsOfScheldules.Count;
                    }
                    optimalScheldules.Scheldules.Add(allVariantsOfScheldules[j]);
                }
            }

            ResultCombinationOfScheldules tmpCombinationOfScheldules = optimalScheldules.Copy();
            foreach (ResultScheldule scheldule in allVariantsOfScheldules)
            {
                tmpCombinationOfScheldules.Scheldules[hallNum] = scheldule;
                if (hallNum != hallsCount - 1)
                {
                    tmpCombinationOfScheldules = GetOptimalScheldules(hallsCount, hallNum + 1, allVariantsOfScheldules, tmpCombinationOfScheldules);
                }
                if (tmpCombinationOfScheldules.UniqFilmsInScheldules.Count > optimalScheldules.UniqFilmsInScheldules.Count)
                {
                    optimalScheldules = tmpCombinationOfScheldules.Copy();
                }
                else if (tmpCombinationOfScheldules.UnusedWorkingTime < optimalScheldules.UnusedWorkingTime)
                {
                    optimalScheldules = tmpCombinationOfScheldules.Copy();
                }
            }
            return optimalScheldules;

            //List<ResultScheldule> tmpScheldules = CopySchelduleList(optimalScheldules);
            //foreach (ResultScheldule scheldule in allVariantsOfScheldules)
            //{
            //    tmpScheldules[hallNum] = scheldule;
            //    if (GetUniqFilms(tmpScheldules).Count > GetUniqFilms(optimalScheldules).Count)
            //    {
            //        optimalScheldules = tmpScheldules;
            //    }
            //    else if ()
            //        { }
            //}
        }
    }
}
