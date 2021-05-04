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
                    List<Film> tmp = new List<Film>();
                    tmp.AddRange(CurrentSchedule);
                    RemainingWorkingTime -= film.RunningTime;
                    Node next = new Node(RemainingWorkingTime, Films, tmp);
                    Next.Add(next);
                    next.CreateGraph();
                }
            }
        }

        public ResultScheldule GetResultScheldule()
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
                    results.Add(next.GetResultScheldule());
                }
                ResultScheldule optimalResult = results[0];
                for (int i = 1; i < results.Count; i++)
                {
                    if (optimalResult.Films.Count < results[i].Films.Count)
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
    }
}
