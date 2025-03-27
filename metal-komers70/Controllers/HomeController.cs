using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using metal_komers70.Models;
using metal_komers70.Views.Services;
using Microsoft.AspNetCore.Mvc;
using metal_komers70.Data;

namespace metal_komers70.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private AppDbContext _context;

        public HomeController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        // Създай клас в папка модели ContactFormViewModel
        // Просто
        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormViewModel model)
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                try
                {
                    ContactFormModel contact = new()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Message = model.Message
                    };

                    //await _emailService.SendContactFormAsync(
                    //    model.Name,
                    //    model.Email,
                    //    model.Phone,
                    //    model.Message);

                    TempData["Message"] = "Thank you for your message!";

                    _context.Contacts.Add(contact);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "Error sending message. Please try again later.";
                    // Log the exception
                }
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


