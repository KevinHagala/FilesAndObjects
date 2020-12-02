using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndObjects
{
    class Program
    {
        class Movie
        {
            public string title;
            public string rating;
            public string year;

            public Movie(string _title, string _rating, string _year)
            {
                title = _title;
                rating = _rating;
                year = _year;
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"imdb.txt";
            //a list to stor movies from the file
            List<string> movielist = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();
            List<Movie> listOfMovies = new List<Movie>();

            foreach(string movieItem in movielist)
            {
                string[] tempArray = movieItem.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Movie newMovie = new Movie(tempArray[0], tempArray[1], tempArray[2]);

                listOfMovies.Add(newMovie);
            }

            foreach(Movie movie in listOfMovies)
            {
                Console.WriteLine($"Title: {movie.title}; Rating: {movie.rating}; Year: {movie.year}");
            }

            Console.WriteLine("What is your favoritite movie? enter the title:");
            string favMovieTitle = Console.ReadLine();
            Console.WriteLine("Enter your favorite movie rating:");
            string favMovieRating = Console.ReadLine();
            Console.WriteLine("Enter the release year:");
            string favMovieYear = Console.ReadLine();

            Movie favMovie = new Movie(favMovieTitle, favMovieRating, favMovieYear);
            string favMovieLine = $"{favMovie.title};{favMovie.rating};{favMovie.year}";

            movielist.Add(favMovieLine);
            File.WriteAllLines(Path.Combine(filePath, fileName), movielist);

        }
    }
}
