using IStore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IStore.Web.Models
{
    public class NewProductViewModel
    {
        [BindNever]
        public IEnumerable<Category> Categories { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
