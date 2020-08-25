using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Enter Name")]
        [MaxLength(7)]
        [StringLength(3,ErrorMessage ="Name can't be less than 20char")]
        [Required]
        public string name { get; set; }
        [Display(Name = "SurName")]
        [StringLength(5)]
        [Required(ErrorMessage = "SurName can't be empty")]
        public string surname { get; set; }

        [Display(Name = "Adress")]
        [StringLength(15)]
        [Required]
        public string adress { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(18)]
        [Required]
        [Phone]
        public string phone { get; set; }
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "SurName can't be empty")]
        [EmailAddress]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime  { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
