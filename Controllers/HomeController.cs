using AuthenticationandAuthorization.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;
using AuthenticationandAuthorization.Models;

namespace AuthenticationandAuthorization.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Securing()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost("login")]
        public IActionResult Validate(string returnUrl, [Bind] DB ad)
        {
            int res = dbop.Login_checking(ad);
            if (res == 1)
            {
                TempData["msg"] = "Welcome he Test user";
            }
            else
            {
                TempData["msg"] = "sernam or Password is wrong";
            }
            return View();
        }
            /*
            ViewData["ReturnUrl"] = returnUrl;
            if(username == "bob" || password == "user@123")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                var claims_identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claims_Principle = new ClaimsPrincipal(claims_identity);
                await HttpContext.SignInAsync(claims_Principle);
                return Redirect(returnUrl);
            }
            TempData["Wrongcredientials"] = "Wrongcredientials. Wrong username or password";
            return View("login");
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
            */
    }
}