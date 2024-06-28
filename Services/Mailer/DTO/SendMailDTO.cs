namespace Services
{

    public class MailDTO
    {
        public string from { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string html { get; set; }
    }

    public class SendMailDTO
    {
        public MailDTO[] emails { get; set; }
    }
}
