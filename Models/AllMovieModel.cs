using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DotnetFlix.Models
{

    public class AllMovie
    {
        public NewMovie NewMovie{get;set;}
        public AvailableMovie AvailableMovie{get;set;}

    }

    public class AvailableMovie
    {
        public List<Movie> AvailableMovies { get; set; }

    }
}

