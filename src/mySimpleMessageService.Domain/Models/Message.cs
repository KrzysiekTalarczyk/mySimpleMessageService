namespace mySimpleMessageService.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Body { get; set; }

        private Message()
        {
        }

        public static Message Create(int senderId, MessageContent content, int recipientId)
        {
            return new Message() { Body = content.ToString() };
        }

        //public class MessageBody
        //{
        //}
    }
}
