using System.Collections;
using UnityEngine;

public enum GameState
{
    Playing,
    Pause,
    GameOver
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectGameOverCanvas;
    [SerializeField] private int _timeToStartTheGame;

    public UIManager UIManager;
    public TwitchChat TwitchChat;
    public PlayersManager PlayersManager;
    public PlayerListManager PlayerListManager;

    public GameState GameState { get; private set; }
    public static GameManager Instance;

    private GameManager() { }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        TwitchChat = TwitchChat.Instance;
    }

    private void Start()
    {
        StopGame();
    }

    public IEnumerator StartGame()
    {
        for (int countDownTime = _timeToStartTheGame; countDownTime > 0; countDownTime--)
        {
            DisplayTextOnScreen(countDownTime.ToString());
            yield return new WaitForSeconds(1f);
        }

        DisplayTextOnScreen("RUN!");
        yield return new WaitForSeconds(0.01f);

        GameState = GameState.Playing; 
        PlayersManager.PlayersMoveManager(false);
    }

    private void DisplayTextOnScreen(string text)
    {
        UIManager.DisplayTextOnScreen(text);
        TwitchChat.WriteChat(text);
    }

    public void StopGame()
    {
        GameState = GameState.Pause;
        PlayersManager.PlayersMoveManager(true);
    }

    public void GameOver()
    {
        GameState = GameState.GameOver;

        _gameObjectGameOverCanvas.SetActive(true);

        //ZASTANOW SIE CZY USUWAC TO UI hmm
       // Destroy(UIManager.gameObject);
    }
}
