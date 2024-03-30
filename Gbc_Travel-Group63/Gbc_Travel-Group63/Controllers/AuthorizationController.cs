using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gbc_Travel_Group63.Models;
using Gbc_Travel_Group63.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


public class AuthorizationController : Controller
{

    private readonly IEmailSender _emailSender;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthorizationController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }

    public IActionResult Signin(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signin(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(model);
    }


    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signup(SignupViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                System.Diagnostics.Debug.WriteLine("About to send an email to " + model.Email);
                var email = model.Email;
                var subject = "Welcome to our application!";
                var message = "Thank you for registering.";
                await _emailSender.SendEmailAsync(email, subject, message);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("SuccessfulSignUp");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            

        }
        return View(model);
    }

    public IActionResult SuccessfulSignUp(){
        return View();
    }

    
}
