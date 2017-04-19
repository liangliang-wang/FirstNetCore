namespace FirstNetCore.Web
{
    internal class CookieAuthenticationOptions
    {
        public string AuthenticationScheme { get; set; }
        public object LoginPath { get; set; }
        public object AccessDeniedPath { get; set; }
        public bool AutomaticAuthenticate { get; set; }
        public bool AutomaticChallenge { get; set; }
    }
}