using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipRazor.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Username { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");   
            }
            return Page();
        }
    }
}
