namespace ABPCMS.HangfireServiceBase
{
    public class SendEmailInput
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public long TargetUserId { get; set; }
    }
}