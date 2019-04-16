using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DotnetFlix.Models
{
    public class Dashboard
    {
        public User CurrentUser{get;set;}
        public int WatchedMovies{get;set;}
        public List<Movie> CurrentCheckedout  {get;set;}
    }
}
