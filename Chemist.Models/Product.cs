using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "List price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "price to below 50")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 10000)]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "price for 100+")]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Chemical type")]
        public int ChemTypeId { get; set; }
        [ValidateNever]
        public ChemType ChemType { get; set; }
    }
}
