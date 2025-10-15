using Microsoft.AspNetCore.Identity;

namespace StockManagementMVC.Models.ViewModel
{
    public class UserWithRolesViewModel
    {
        public IdentityUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}
