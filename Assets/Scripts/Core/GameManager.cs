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
    public PlayersManager PlayersManager;
    public TwitchChat TwitchChat;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
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

    public void DestroyPlayer(GameObject gameObject, bool isDead)
    {
        if (isDead == true)
        {
            UIManager.PopupMessageItemManager.InstantiateItem(gameObject.name, ItemType.Death);
        }
        else 
        {
            UIManager.PopupMessageItemManager.InstantiateItem(gameObject.name, ItemType.Winning);
        }

        PlayersManager.ListGameObjectsPlayers.Remove(gameObject);
        PlayersManager.SetTextPlayersCounter();

        Destroy(gameObject);

        CheckIsTheGameOver();
    }

    public void Winner(GameObject gameObject)
    {
        string time = UIManager.Timer.GetTime();
        PlayersManager.DictionaryGameObjectsWinners.Add(gameObject, time);

        UIManager.HighscoreManager.InstantiateItem(gameObject.name + " - " + time);
        //UIManager.HighscoreManager.ChangeColorHighscoreItem(gameObject.name, Color.green);

        DestroyPlayer(gameObject, false);
    }

    private void CheckIsTheGameOver()
    {
        if (PlayersManager.ListGameObjectsPlayers.Count == 0)
        {
            Debug.LogWarning("GAME OVER");
        }
    }
}
