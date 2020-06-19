using System.ComponentModel.DataAnnotations;

namespace CzTrainApi.ViewModels.Login
{
    /// <summary>
    /// Login Request
    /// </summary>
    public class LoginRequestVM
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string User { get; set; }

        /// <summary>
        /// Passwort
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
