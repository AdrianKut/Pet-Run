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
    public GameState GameState { get; private set; }
    public static GameManager Instance;

    private GameManager() { }

    public UIManager UIManager;
    public TwitchChat TwitchChat;
    public PlayersManager PlayersManager;
    public PlayerListManager PlayerListManager;

    [SerializeField] private GameObject _gameObjectGameOverCanvas;

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
        //10sec countdown
        //for (int countDownTime = 10; countDownTime > 0; countDownTime--)
        //{
        //    DisplayTextOnScreen(countDownTime.ToString());
        //    yield return new WaitForSeconds(1f);
        //}

        yield return new WaitForSeconds(0.1f);
        DisplayTextOnScreen("RUN!");
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

        Destroy(UIManager.gameObject);
    }
}
