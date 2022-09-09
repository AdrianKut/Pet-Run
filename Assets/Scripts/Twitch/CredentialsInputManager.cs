using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CredentialsInputManager : MonoBehaviour
{
    [Header("Input fields")]
    [SerializeField] private TMP_InputField _inputFieldPassword;
    [SerializeField] private TMP_InputField _inputFieldUsername;
    [SerializeField] private TMP_InputField _inputFieldChannelName;
    [SerializeField] private TextMeshProUGUI _errorText;
  
    [Header("Buttons")]
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonConnect;

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
            _errorText.text = "INPUT INVALID!";
        }
        else
        {
            PlayerPrefs.SetString("password", _inputFieldPassword.text);
            PlayerPrefs.SetString("username", _inputFieldUsername.text.ToLower());
            PlayerPrefs.SetString("channelname", _inputFieldChannelName.text.ToLower());

            _twitchChat.gameObject.SetActive(true);
            _twitchChat.InitialCredentialsAndTryConnect();

            _errorText.color = Color.green;
            _errorText.text = "Connection established!";
            _buttonStart.interactable = true;
        }
    }
}
