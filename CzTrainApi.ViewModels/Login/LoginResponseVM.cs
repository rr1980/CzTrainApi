namespace CzTrainApi.ViewModels.Login
{
    /// <summary>
    /// Login Response
    /// </summary>
    public class LoginResponseVM
    {
        /// <summary>
        /// Authentifizierungstoken
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// BeutzerRolle
        /// </summary>
        public string BenutzerRolle { get; set; }
    }
}
