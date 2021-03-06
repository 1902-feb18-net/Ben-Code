﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class MovieRepository
    {
        private readonly IList<Movie> _moviesData;
        private readonly IList<Genre> _genreData;

        public MovieRepository(IList<Movie> moviesData, IList<Genre> genreData)
        {
            _moviesData = moviesData;
            _genreData = genreData;
        }

        public IEnumerable<Movie> AllMovies()
        {
            return _moviesData.ToList();
        }

        public IEnumerable<Movie> AllMoviesWithGenre(Genre genre)
        {
            return _moviesData.Where(m => m.Genre.Id == genre.Id).ToList();
        }

        public Movie MovieById(int Id)
        {
            return _moviesData.First(m => m.Id == Id);
        }

        public Genre GenreById(int id)
        {
            return _genreData.First(g => g.Id == id);
        }

        public void Create(Movie movie)
        {
            if (_moviesData.Count == 0)
            {
                movie.Id = 1;
            }
            else
            {
                int id = _moviesData.Max(m => m.Id) + 1;
                movie.Id = id;
            }
            _moviesData.Add(movie);

        }

        public void Update(int id, Movie movie)
        {
            var oldMovie = MovieById(id);
            oldMovie.Title = movie.Title;
            oldMovie.Genre = GenreById(movie.Genre.Id);
            oldMovie.DateReleased = movie.DateReleased;
        }

        public void DeleteMovie(int id)
        {
            _moviesData.Remove(MovieById(id));
        }
    }
}
