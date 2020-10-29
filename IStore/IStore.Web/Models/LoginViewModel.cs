using System.ComponentModel.DataAnnotations;

namespace IStore.Web.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Url]
        public string ReturnUrl { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
