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
    public class HomeController : Controller
    {
        private FlixContext dbContext;
        public HomeController(FlixContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(NewUser newUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                if (dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<NewUser> Hasher = new PasswordHasher<NewUser>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    User addUser = newUser.GetNewuser();
                    dbContext.Users.Add(addUser);
                    dbContext.SaveChanges();
                    Loginuser.SetLogin(HttpContext, addUser.UserId);
                    return Redirect("Dashboard");
                }
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {

            int UserId = Loginuser.GetUserID(HttpContext);
            if (UserId == 0)
            {
                ViewBag.message = " Need Register or login first!";
                return View("Warning");
            }
            Dashboard Dashboard = SetupDashboard(UserId);
            return View(Dashboard);
        }

        public Dashboard SetupDashboard(int userid) 
        {
            Dashboard Dashboard = new Dashboard();
            Dashboard.CurrentUser = dbContext.Users.FirstOrDefault(user => user.UserId == userid);
            Dashboard.WatchedMovies = dbContext.Borrows.Where(bor => ((bor.UserId == userid)&&(bor.isReturnd == true))).Count();
            List<Movie> checkedMovie = dbContext.Movies
            .Include(movie=> movie.Borrows)
            .Where(mov => mov.Borrows.Any(bor => (bor.UserId == userid) && (!bor.isReturnd)))
            .ToList();
            Dashboard.CurrentCheckedout = checkedMovie;

            return Dashboard;
        } 

        [HttpPost("Login")]
        public IActionResult Login(Loginuser newLoginUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                User needLogin = dbContext.Users.FirstOrDefault(u => u.Email == newLoginUser.LogEmail);
                if (needLogin == null)
                {
                    ModelState.AddModelError("LogEmail", "This email didn't exist.Please rigester first!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                var verifyPass = Hasher.VerifyHashedPassword(needLogin, needLogin.Password, newLoginUser.LogPassword);
                if (verifyPass == 0)
                {
                    ModelState.AddModelError("LogPassword", "Password is wrong!");
                    return View("Index");
                }
                else
                {
                    Loginuser.SetLogin(HttpContext, needLogin.UserId);
                    return Redirect("Dashboard");
                }
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }



    }
}
