using InventoryManagementRepository.DTO;
using InventoryManagementService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagementGUI.Pages;

public class Login : PageModel
{
    private readonly IAccountService _accountService;

    public Login(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty] public LoginAccount LoginAccount { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
            return Page();
        var acc =
            _accountService.GetAccountByUserNameAndPassword(LoginAccount.UserName, LoginAccount.Password);
        if (acc != null)
        {
            HttpContext.Session.SetInt32("Role", acc.Role.Value);
            HttpContext.Session.SetString("Name", acc.Name);
            return Redirect("https://localhost:7165/Home");
        }

        return Page();
    }
}