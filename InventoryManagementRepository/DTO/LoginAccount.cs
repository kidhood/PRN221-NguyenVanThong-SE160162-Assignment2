using System.ComponentModel.DataAnnotations;

namespace InventoryManagementRepository.DTO;

public class LoginAccount
{
    [Required(ErrorMessage = "User name is required!")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Length of user name is 3 -20")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Length of Password is 3 -20")]
    public string Password { set; get; }
}