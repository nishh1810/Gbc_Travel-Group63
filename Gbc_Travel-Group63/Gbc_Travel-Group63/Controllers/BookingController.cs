// BookingController.cs
using Microsoft.AspNetCore.Mvc;
using Gbc_Travel_Group63.Models;
using Gbc_Travel_Group63.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;


public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;


    public BookingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Action to display booking details
    public IActionResult Book(string bookingType, int itemId)
    {
        // Fetch details from the database based on bookingType and itemId
        // This could involve querying flights, hotels, or cars depending on the bookingType

        // Assuming you have a method to fetch details based on bookingType and itemId
        

        Random rnd = new Random();

        var viewModel = new Booking
        {
            // Populate the ViewModel with details
            BookingType = bookingType,
            ItemId = itemId,
            BookingId = rnd.Next(1, 1000000),
            IsGuest = false,
            UserId = ""
            // Add other necessary properties
        };

        return View("Book", viewModel);
    }

    // Action to confirm the booking
    [HttpPost]
    public IActionResult ConfirmBooking(Booking viewModel)
    {
        Console.WriteLine(viewModel.BookingId);
        Console.WriteLine(viewModel.IsGuest);
        Console.WriteLine(viewModel.UserId);
        Console.WriteLine(viewModel.BookingType);
        Console.WriteLine(viewModel.ItemId);
        if (ModelState.IsValid)
        {
            // Implement your booking confirmation logic here
            // For example, create a booking record in the database

            viewModel.IsGuest = !User.Identity.IsAuthenticated;

            // If the user is not authenticated, generate a random guest ID
            if (viewModel.IsGuest)
            {
                Random rnd = new Random();
                viewModel.UserId = "Guest_" + rnd.Next(1, 100000000);
            }
            else
            {
                // If the user is authenticated, set userId to the actual user ID
                viewModel.UserId = User.Identity.Name;
            }
            var user = _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                viewModel.UserId = user.Id;
            }
            

            // Create a new Booking entity
            var newBooking = new Booking
            {
                BookingType = viewModel.BookingType,
                ItemId = viewModel.ItemId,
                IsGuest = viewModel.IsGuest,
                BookingId = viewModel.BookingId,
                UserId = viewModel.UserId
                // Add other necessary properties
            };



            Console.WriteLine(newBooking);

            // Save the booking to the database
            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            // Redirect to the confirmation page with the booking ID
            return RedirectToAction("Confirmation", new { bookingId = newBooking.BookingId });
        }

        // If there are validation errors, return to the booking details page
        return View("Book", viewModel);
    }

    // Action to display the confirmation page
    public IActionResult Confirmation(int bookingId)
    {
        // Fetch the booking details based on the bookingId
        var confirmedBooking = _context.Bookings.Find(bookingId);

        // Pass the details to the confirmation view
        return View("ConfirmBooking", confirmedBooking);
    }

    // Method to fetch booking details based on bookingType and itemId
    private Booking GetBookingDetails(string bookingType, int itemId)
    {
        // Implement logic to fetch details from the database based on bookingType and itemId
        // This could involve querying flights, hotels, or cars depending on the bookingType

        // Sample implementation
        var details = new Booking
        {
            BookingType = bookingType,
            ItemId = itemId,
            // Add other necessary properties
        };

        return details;
    }
}
