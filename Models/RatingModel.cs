using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DotnetFlix.Models
{
    public class RatingModel
    {
        public int MovieId{get;set;}
        public int UserId{get;set;}

        public int RatingValue{get;set;}
    }

}