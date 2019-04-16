using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DotnetFlix.Models
{
    public class MovieDetail
    {
        public Movie Movie{get;set;}
        public string AverageRating{get;set;}

        public string YourRating{get;set;}
    }
}