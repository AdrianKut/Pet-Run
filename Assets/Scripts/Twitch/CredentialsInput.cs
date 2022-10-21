using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CredentialsInput : MonoBehaviour
{
    [Header("Input fields")]
    [SerializeField] private TMP_InputField _inputFieldPassword;
    [SerializeField] private TMP_InputField _inputFieldUsername;
    [SerializeField] private TMP_InputField _inputFieldChannelName;
    [SerializeField] private TextMeshProUGUI _textMessage;
  
    [Header("Buttons")]
    [SerializeField] private Button _buttonStart;

    [Space]
    [SerializeField] private TwitchChat _twitchChat;

    private void Start()
    {
        _inputFieldPassword.text = PlayerPrefs.GetString("password");
        _inputFieldUsername.text = PlayerPrefs.GetString("username");
        _inputFieldChannelName.text = PlayerPrefs.GetString("channelname");
    }

    public void AsignCredentials()
    {
        if (string.IsNullOrEmpty(_inputFieldPassword.text) ||
            string.IsNullOrEmpty(_inputFieldUsername.text) ||
            string.IsNullOrEmpty(_inputFieldChannelName.text))
        {
            _textMessage.text = "INPUT INVALID!";
        }
        else
        {
            PlayerPrefs.SetString("password", _inputFieldPassword.text);
            PlayerPrefs.SetString("username", _inputFieldUsername.text.ToLower());
            PlayerPrefs.SetString("channelname", _inputFieldChannelName.text.ToLower());

            _twitchChat.gameObject.SetActive(true);
            _twitchChat.InitialCredentialsAndTryConnect();

            _textMessage.color = Color.green;
            _textMessage.text = "Connection established!";
            _buttonStart.interactable = true;
        }
    }
}
