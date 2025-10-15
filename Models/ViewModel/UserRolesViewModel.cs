namespace StockManagementMVC.Models.ViewModel
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<RoleSelection> Roles { get; set; }
    }
}
