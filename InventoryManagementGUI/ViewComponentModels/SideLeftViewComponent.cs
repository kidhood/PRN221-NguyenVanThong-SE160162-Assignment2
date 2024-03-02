using InventoryManagementRepository.Model;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementGUI.ViewComponentModel;

public class SideLeftViewComponent : ViewComponent
{
    private AlreadyLoginModel _alreadyLoginModel;

    public IViewComponentResult Invoke()
    {
        _alreadyLoginModel = new AlreadyLoginModel();
        if (HttpContext.Session.IsAvailable)
        {
            _alreadyLoginModel.Name = HttpContext.Session.GetString("Name") ?? string.Empty;
            _alreadyLoginModel.Role = HttpContext.Session.GetInt32("Role") ?? 1;
        }

        return View(_alreadyLoginModel);
    }
}