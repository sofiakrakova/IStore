using System.ComponentModel.DataAnnotations;

namespace IStore.Web.Models
{
    public class RegistrationViewModel
    {
        public string Credentials { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public string About { get; set; }

        [Url]
        public string ReturnUrl { get; set; }
    }
}
