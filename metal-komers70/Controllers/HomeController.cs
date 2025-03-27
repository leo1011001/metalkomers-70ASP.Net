using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using metal_komers70.Models;
using metal_komers70.Views.Services;
using Microsoft.AspNetCore.Mvc;

namespace metal_komers70.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
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

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _emailService.SendContactFormAsync(
                        model.Name,
                        model.Email,
                        model.Phone,
                        model.Message);

                    TempData["Message"] = "Thank you for your message!";
                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error sending message. Please try again later.");
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


