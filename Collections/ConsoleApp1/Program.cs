using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        public static IEnumerable<double> Random()
        {
            while (true) {
                Random rand = new Random();
                yield return rand.NextDouble();
            } 
        }
        static void Main(string[] args)
        {
            //var movies = new List<Movie> {
            //   new Movie { Name="ABC", Rating=8,Year=1999} ,
            //   new Movie { Name = "DEF", Rating = 8, Year = 1999 } ,
            //   new Movie { Name = "GHI", Rating = 8, Year = 1999 },
            //   new Movie { Name = "JKL", Rating = 8, Year = 1999 } };

            //var filteredMovies = movies.FindAll(x => x.Rating > 7);




            //foreach(var movie in filteredMovies)
            //{
            //    Console.WriteLine(movie.Name);
            //}


            var query = Random().Where(x => x > 0.5).Take(15);
            foreach(var number in query)
            {
                Console.WriteLine(number);
                
            }
            
        }
    }
}
