using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Film> Films = new List<Film>();
            //Films.Add(new Film("Die Hard", 100));
            //Films.Add(new Film("LOTR", 180));
            //Films.Add(new Film("Pokemon", 120));
            CinemaManager cinemaManager = new CinemaManager();
            cinemaManager.SetRepertoire();

            Node CinemaScheldules = new Node(600, 840, cinemaManager.Repertoire);
            CinemaScheldules.CreateGraph();
            //List<ResultScheldule> results = CinemaScheldules.GetAllVariantsOfScheldule();
            //Console.WriteLine(CinemaScheldules.GetOptimalScheldule());
            ResultCombinationOfScheldules result = CinemaScheldules.GetOptimalScheldules(3);
            Console.WriteLine("Расписание:");
            for (int i = 0; i <  result.Scheldules.Count; i++)
            {
                Console.WriteLine($"зал {i+1}");
                Console.WriteLine(result.Scheldules[i]);
            }
        }
    }
}
