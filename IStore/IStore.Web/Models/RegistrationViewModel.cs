using System.ComponentModel.DataAnnotations;

namespace IStore.Web.Models
{
    public class RegistrationViewModel
    {
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Credentials { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }
}
