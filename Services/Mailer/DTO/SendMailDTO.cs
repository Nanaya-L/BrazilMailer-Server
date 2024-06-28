namespace Services
{
    public class AttachmentsDTO
    {
        public string filename { get; set; }
        public string path { get; set; }
    }
    public class MailDTO
    {
        public string from { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string html { get; set; }
        public AttachmentsDTO[] attachments { get; set; }
    }

    public class SendMailDTO
    {
        public string token { get; set; }
        public MailDTO[] emails { get; set; }
    }
}
