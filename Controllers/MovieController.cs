using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetFlix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DotnetFlix.Controllers
{
    public class MovieController : Controller
    {
        private FlixContext dbContext;
        public MovieController(FlixContext context)
        {
            dbContext = context;
        }
        [Route("/Movies")]
        [HttpGet]
        public IActionResult Movies()
        {
            if (Loginuser.GetUserID(HttpContext) == 0)
            {
                ViewBag.message = " Session time out!";
                return View("Warning");
            }

            AllMovie AllMovie = initAllmovie();
            return View("AllMovie",AllMovie);
        }


        public AllMovie initAllmovie()
        {
            AllMovie AllMovie = new AllMovie();
            AllMovie.NewMovie = new NewMovie();
            AllMovie.AvailableMovie = new AvailableMovie();
            AllMovie.AvailableMovie.AvailableMovies=dbContext.Movies.Where(movie => movie.isAvailable).ToList();
            return AllMovie;
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(NewMovie newMovie)
        {
            if(Loginuser.GetUserID(HttpContext)==0)
            {
                ViewBag.message = " Session time out!";
                return View("Warning");
            }

            if (!ModelState.IsValid)
            {
                AllMovie AllMovie = initAllmovie();
                return View("AllMovie", AllMovie);
            }
            else
            {
                if (newMovie.ReleasedYear > DateTime.Today.Year )
                {
                    ModelState.AddModelError("ReleasedYear", "ReleasedYear  can not be in the future!");
                    AllMovie AllMovie = initAllmovie();
                    return View("AllMovie", AllMovie);
                }
                else
                {
                    newMovie.UserId = Loginuser.GetUserID(HttpContext);
                    dbContext.Movies.Add(newMovie.GetNewMovie());
                    dbContext.SaveChanges();
                    AllMovie AllMovie = initAllmovie();
                    return View("AllMovie", AllMovie);
                }
            }
        }

        [HttpGet("/Movies/{movieId}")]
        public IActionResult ShowMovieDetail(int movieId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            if (currentUser == 0)
            {
                ViewBag.message = " Session time out!";
                return View("Warning");
            }
            MovieDetail MovieDetail = GetMovieDetail(movieId,currentUser);
            return View(MovieDetail);
        }
        [HttpGet("/Movies/checkout/{movieId}")]
        public IActionResult Checkout(int movieId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            if (currentUser == 0)
            {
                ViewBag.message = " Session time out!";
                return View("Warning");
            }
            if (dbContext.Borrows.Where(bor => (bor.UserId == currentUser)&&(bor.isReturnd ==false)).Count()>=5) 
            {
                return Redirect("/Movies/"+movieId);
            }
            Borrow checkout = new Borrow();
            checkout.MovieId = movieId;
            checkout.UserId = currentUser;
            checkout.RatingValue = 0;
            checkout.isReturnd = false;
            dbContext.Borrows.Add(checkout);
            dbContext.SaveChanges();
            
            Movie thisMovie = dbContext.Movies.FirstOrDefault(movie => movie.MovieId == movieId);
            thisMovie.isAvailable = false;
            dbContext.SaveChanges();
            return Redirect("/Dashboard");
        }
        [HttpGet("/Movies/return/{movieId}")]
        public IActionResult ReturnMovie(int movieId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            if (currentUser == 0)
            {
                ViewBag.message = " Session time out!";
                return View("Warning");
            }
            
            Borrow currentBorrow = dbContext.Borrows.FirstOrDefault(bor => (bor.MovieId==movieId)&&(!bor.isReturnd) );
            if(currentBorrow.UserId != currentUser)
            {
                ViewBag.message = " This Movie is not checked out by you. You can not return it!!";
                return View("Warning");
            }
            RatingModel RatingModel = new RatingModel();
            RatingModel.UserId = currentUser;
            RatingModel.MovieId= movieId;
            return View(RatingModel);
        }

        [HttpPost("ActionReturnMovie")]
        public IActionResult ActionReturnMovie(RatingModel ratinginfo)
        {
            Console.WriteLine("get return page");
            int currentUser = Loginuser.GetUserID(HttpContext);
            if (currentUser == 0)
            {
                ViewBag.message = " Session time out!";
                return View("Warning");
            }
            Borrow currentBorrow = dbContext.Borrows
            .FirstOrDefault(bor => (bor.MovieId == ratinginfo.MovieId)&&(bor.UserId == ratinginfo.UserId) && (!bor.isReturnd));
            currentBorrow.RatingValue = ratinginfo.RatingValue;
            currentBorrow.isReturnd = true;
            dbContext.SaveChanges();
            Movie thisMovie = dbContext.Movies.FirstOrDefault(movie => movie.MovieId == ratinginfo.MovieId);
            thisMovie.isAvailable = true;
            dbContext.SaveChanges();
            return Redirect("/Dashboard");
        }

        public MovieDetail GetMovieDetail(int movieId,int userId)
        {
            MovieDetail MovieDetail = new MovieDetail();

            MovieDetail.Movie = dbContext.Movies.FirstOrDefault(movie => movie.MovieId == movieId);
            if (dbContext.Borrows.Where(borrow => borrow.MovieId == movieId).Count() == 0)
            {
                MovieDetail.AverageRating = "No one has rated the Movie yet";
            }
            else
            {
                int sumRating = dbContext.Borrows.Where(borrow => borrow.MovieId == movieId).Sum(borrow => borrow.RatingValue);
                int count = dbContext.Borrows.Where(borrow => borrow.MovieId == movieId).Count();
                double averageRating = sumRating / count;
                MovieDetail.AverageRating = averageRating.ToString("0.00");
            }
            if (dbContext.Borrows.FirstOrDefault(bor => (bor.UserId == userId) && (bor.MovieId == movieId))==null)
            {
                MovieDetail.YourRating = "You have not yet rated this movie";
            }
            else
            {
                MovieDetail.YourRating = dbContext.Borrows.
                FirstOrDefault(bor => (bor.UserId == userId) && (bor.MovieId == movieId))
                .RatingValue.ToString();
            }
            
            return MovieDetail;
        }
    }
}