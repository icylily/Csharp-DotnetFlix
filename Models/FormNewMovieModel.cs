using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DotnetFlix.Models
{   

    public class NewMovie
    {
        [Required(ErrorMessage = "Movie's Title is required!")]
        [MinLength(3, ErrorMessage = "Movie's Title Must be 2 characters or longer!")]
        [Display(Name = "Movie's title :")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Genre is required!")]
        [Display(Name = "Genre :")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Genre is required!")]
        [Range(1888,int.MaxValue,ErrorMessage = "Release Year must greater then 1888!")]
        [Display(Name = "ReleaseYear :")]
        public int ReleasedYear{get;set;}

        public int UserId{get;set;}

        public bool isAvailable{get;set;} = true;

        public Movie GetNewMovie()
        {
            Movie newMovie = new Movie();

            newMovie.Title = Title;
            newMovie.Genre = Genre;
            newMovie.ReleasedYear = ReleasedYear;
            newMovie.UserId = UserId;
            newMovie.isAvailable = true;

            return newMovie;
        }
    }
}
