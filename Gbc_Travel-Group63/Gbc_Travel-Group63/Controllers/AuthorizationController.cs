using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gbc_Travel_Group63.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


public class AuthorizationController : Controller
{



    private readonly SignInManager<SignInViewModel> _signInManager;
    private readonly UserManager<SignupViewModel> _userManager;

    public AuthorizationController(
        UserManager<SignupViewModel> userManager,
        SignInManager<SignInViewModel> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Signin(){
        return View();
    }

    public IActionResult Signup()
    {
        return View();
    }

    
}
