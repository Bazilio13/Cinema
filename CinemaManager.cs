using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class CinemaManager
    {
        public List<Film> Repertoire { get; set; }

        public CinemaManager()
        {
            Repertoire = new List<Film>();
        }

        public void SetRepertoire()
        {
            string userInput = "";
            while (userInput != "stop")
            {
                Film film = new Film();
                Console.WriteLine("Введите название фильма");
                userInput = Console.ReadLine();
                film.Name = userInput;
                bool userInputCheck = false;
                while (!(userInput == "stop" || userInputCheck == true))
                {
                    Console.WriteLine("Введите продолжительность фильма в минутах");
                    userInput = Console.ReadLine();
                    foreach (char ch in userInput)
                    {
                        if (!char.IsDigit(ch))
                        {
                            userInputCheck = false;
                            break;
                        }
                        else
                        {
                            userInputCheck = true;
                        }
                    }
                    if (userInputCheck)
                    {
                        film.RunningTime = Convert.ToInt32(userInput);
                        Repertoire.Add(film);
                    }
                    else
                    {
                        Console.WriteLine("Некорректная продолжительность фильма. Введите число либо please enough для отмены добавления нового фильма");
                    }
                }
            }
        }
    }
}
