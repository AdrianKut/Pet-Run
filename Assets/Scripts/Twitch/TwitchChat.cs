using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

public class TwitchChat : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string _username;
    [SerializeField] private string _channelName;
    [SerializeField] private string _password;

    private TcpClient _twitchClient;
    private StreamReader _reader;
    private StreamWriter _writer;

    public static TwitchChat Instance;
    private TwitchChat() { }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //ONLY FOR DEBUG
        InitialCredentialsAndTryConnect();
    }

    void Update()
    {
        if (_twitchClient.Connected == false || _twitchClient == null)
            Connect();

        ReadChat();
    }

    public void InitialCredentialsAndTryConnect()
    {
        InitialCredentials();
        Connect();
    }

    private void InitialCredentials()
    {
        _username = PlayerPrefs.GetString("username");
        _channelName = PlayerPrefs.GetString("channelname");
        _password = PlayerPrefs.GetString("password");
    }

    private void Connect()
    {
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream()) { AutoFlush = true};

        _writer.WriteLine("PASS " + _password);
        _writer.WriteLine("NICK " + _username);
        _writer.WriteLine("USER " + _username + " 8 *:" + _username);
        _writer.WriteLine("JOIN #" + _channelName);
        //_writer.Flush();

        WriteChat("Connection established! SeemsGood");
    }

    public async void WriteChat(string message)
    {
       await _writer.WriteLineAsync($"PRIVMSG #{_channelName} :{message}");
    }

    public void ReadChat()
    {
        if (_twitchClient.Available > 0 && GameManager.Instance != null)
        {
            string message = _reader.ReadLine();
            if (message.Contains("PRIVMSG"))
            {
                // Get the username
                int splitPoint = message.IndexOf("!", 1);
                string chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                //Get the message
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);

                ChatPlayerMessage chatPlayer = new ChatPlayerMessage();
                chatPlayer.User = chatName;
                chatPlayer.Message = message.ToLower();

                GameManager.Instance.PlayersManager.JoinPlayerToTheGame(chatPlayer);
                GameManager.Instance.PlayersManager.PlayerStartOrStopMove(chatPlayer, "!start", false);
                GameManager.Instance.PlayersManager.PlayerStartOrStopMove(chatPlayer, "!stop", true);
            }
        }
    }

    public void Reconnect()
    {
        Connect();
    }
}
