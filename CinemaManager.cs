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
            while (userInput != "please enough")
            {
                Film film = new Film();
                Console.WriteLine("Введите название фильма");
                film.Name = Console.ReadLine();
                bool userInputCheck = true;
                Console.WriteLine("Введите продолжительность фильма в минутах");
                do
                {
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
                while (!(userInput == "please enough" || userInputCheck == true));
            }
        }
    }
}
