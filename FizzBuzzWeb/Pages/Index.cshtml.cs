using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public string Result;

        public string Alert;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            DefaultName();
        }

        public void DefaultName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (FizzBuzz.Number > 1000 || FizzBuzz.Number < 1 || FizzBuzz.Number == null)
                {
                    Result = null;
                    Alert = "alert alert-danger";
                    DefaultName();
                }
                else if (FizzBuzz.Number % 15 == 0)
                {
                    Result = "FizzBuzz";
                    Alert = "alert alert-success";
                    DefaultName();
                }
                else if (FizzBuzz.Number % 3 == 0)
                {
                    Result = "Fizz";
                    Alert = "alert alert-success";
                    DefaultName();
                }
                else if (FizzBuzz.Number % 5 == 0)
                {
                    Result = "Buzz";
                    Alert = "alert alert-success";
                    DefaultName();
                }
                else
                {
                    Result = "Wartość " + FizzBuzz.Number + " nie spełnia kryteriów FizzBuzz.";
                    Alert = "alert alert-danger";
                    DefaultName();
                }

                FizzBuzz.Result = Result;
            }

            return Page();
        }
    }
}