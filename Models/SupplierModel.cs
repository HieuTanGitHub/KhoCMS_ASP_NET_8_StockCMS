using System.ComponentModel.DataAnnotations;

namespace StockManagementMVC.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên nhà cung cấp")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhà cung cấp")]
        [StringLength(500)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập sdt nhà cung cấp")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email nhà cung cấp")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
