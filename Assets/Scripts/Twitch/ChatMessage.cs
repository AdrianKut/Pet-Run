[System.Serializable]
public class ChatPlayerMessage
{
    public string User;
    public string Message;

    public ChatPlayerMessage() { }

    public ChatPlayerMessage(string user, string message)
    {
        User = user;
        Message = message;
    }
}
