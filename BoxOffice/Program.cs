using System;
using System.IO;
using System.Collections.Generic;

namespace BoxOffice
{
    class Program
    {
        class Movie
        {
            int id;
            string title;
            long lifetimeGross;

            public Movie(int _id, string _title, long _lifeTimeGross)
            {
                id = _id;
                title = _title;
                lifetimeGross = _lifeTimeGross;
            }

            public int ID { get { return id; } }
            public string Title { get { return title; } }
            public long LifeTimeGross { get { return LifeTimeGross; } }

        }

        class MovieList
        {
            List<Movie> movies;
            long totalLifeTimeGross;

            public MovieList()
            {
                movies = new List<Movie>();
                totalLifeTimeGross = 0;
            }

            public void AddMoviesToList(int id, string title, long gross)
            {
                Movie newMovie = new Movie(id, title, gross);
                movies.Add(newMovie);
            }
            public void PrintAllMovies()
            {
                foreach (Movie movie in movies)
                {
                    Console.WriteLine($"{movie.ID}, {movie.Title} has earned {movie.LifeTimeGross}");
                }
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"boxOffice.txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            string[] linesFromfile = File.ReadAllLines(fullFilePath);

            MovieList myMovies = new MovieList();

            foreach(string line in linesFromfile)
            {
                string[] tempArray = line.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                int movieId = int.Parse(tempArray[0]);
                string movieTitle = tempArray[1];
                string totalGrossTemp = tempArray[2].Substring(1);
                Console.WriteLine(totalGrossTemp);
                long movieGross = long.Parse(totalGrossTemp);

                myMovies.AddMoviesToList(movieId, movieTitle, movieGross);
            }

        }
        
    }
}
