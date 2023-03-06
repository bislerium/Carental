namespace Infrastructure.Mailing
{
    internal class SmtpSetting
    {
        internal string Host { get; set; } = string.Empty;
        internal int Port { get; set; }
        internal string User { get; set; } = string.Empty;
        internal string Password { get; set; } = string.Empty;
    }
}
