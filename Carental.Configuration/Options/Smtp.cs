namespace Carental.Configuration.Options 
{ 
    public class Smtp
    {
        public const string SectionName = "Smtp";
        public int Port { get; set; }
        public string From { get; set; } = null!;
        public string Server { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsSsl { get; set; }
    }
}
