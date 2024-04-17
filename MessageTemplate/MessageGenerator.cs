



namespace MessageTemplate
{
    public class MessageTemplateCreator
    {   
        public string GenerateJsonMessage(dynamic message)
        {
            var asci = Encoding.ASCII.GetBytes(message.ToString());
            return JsonSerializer.Serialize(message);
        }
    }
}
