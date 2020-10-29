using System.ComponentModel.DataAnnotations;

namespace IStore.Web.Models
{
    public class RegistrationViewModel
    {
        [DataType(DataType.Text)]
        public string Credentials { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }
}
