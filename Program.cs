using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Film> Films = new List<Film>();
            Films.Add(new Film("Die Hard", 100));
            Films.Add(new Film("LOTR", 180));
            Films.Add(new Film("Pokemon", 120));

            Node CinemaScheldules = new Node(840, Films);
            CinemaScheldules.CreateGraph();
            Console.WriteLine(CinemaScheldules.GetResultScheldule());
        }
    }
}
