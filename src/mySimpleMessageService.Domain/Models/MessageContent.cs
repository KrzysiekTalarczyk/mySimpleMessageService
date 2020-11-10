namespace mySimpleMessageService.Domain.Models
{
    public class MessageContent
    {
        public string Text { get; set; }

        private MessageContent(){}
       
        public static MessageContent Create(string body) => new MessageContent(){Text = body};
    }
}
