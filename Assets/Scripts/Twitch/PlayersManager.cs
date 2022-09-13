using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _textPlayersCounter;
    private int _numberOfPlayers = 0;

    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private Transform _destinationPosition;
    [SerializeField] private GameObject _gameObjectPlayer;

    public List<GameObject> ListGameObjectsPlayers = new List<GameObject>();
    public Dictionary<string, string> DictionaryGameObjectsWinners = new Dictionary<string, string>();
    public Dictionary<string, string> DictionaryGameObjectsLosers = new Dictionary<string, string>();

    public void JoinPlayerToTheGame(ChatPlayerMessage chatPlayerMessage)
    {
        var isAdded = false;
        foreach (var item in ListGameObjectsPlayers)
        {
            if (item.name == chatPlayerMessage.User)
            {
                isAdded = true;
                break;
            }
        }

        if (chatPlayerMessage.Message == "!j" && isAdded == false && GameManager.Instance.GameState == GameState.Pause)
        {
            SpawnNewPlayer(chatPlayerMessage.User);
            GameManager.Instance.UIManager.PopupMessageItemManager.InstantiateItem(chatPlayerMessage.User, ItemType.NewPlayer);

            _numberOfPlayers++;
            SetTextPlayersCounter();
        }
    }

    public void SpawnNewPlayer(string nickname)
    {
        var randomXPos = Random.Range(_spawnZone.GetMinX(), _spawnZone.GetMaxX());
        var randomZPos = Random.Range(_spawnZone.GetMinZ(), _spawnZone.GetMaxZ());

        Vector3 spawnPos = new Vector3(randomXPos, 1f, randomZPos);

        var newPlayer = Instantiate(_gameObjectPlayer, spawnPos, Quaternion.identity);
        newPlayer.name = nickname;
        newPlayer.transform.GetChild(0).GetComponent<TextMeshPro>().text = nickname;

        newPlayer.GetComponent<Player>().SetDestinationPosition(_destinationPosition);

        ListGameObjectsPlayers.Add(newPlayer);

        GameManager.Instance.PlayerListManager.InstantiateItem($"{ListGameObjectsPlayers.Count}. {nickname}", Color.white);
    }

    public void PlayerStartOrStopMove(ChatPlayerMessage chatPlayerMessage, string command, bool isStopped)
    {
        if (GameManager.Instance.GameState == GameState.Playing)
        {
            foreach (var item in ListGameObjectsPlayers)
            {
                if (item.name == chatPlayerMessage.User && chatPlayerMessage.Message == command)
                {
                    item.GetComponent<Player>().Agent.isStopped = isStopped;
                    break;
                }
            }
        }
    }

    public void PlayersMoveManager(bool isStopped)
    {
        if (ListGameObjectsPlayers.Count == 0 && isStopped == false)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            foreach (var item in ListGameObjectsPlayers)
            {
                item.GetComponent<Player>().Agent.isStopped = isStopped;
            }
        }
    }

    public void SetTextPlayersCounter()
    {
        _textPlayersCounter.text = $"{ListGameObjectsPlayers.Count}/{_numberOfPlayers}";
    }

    public void DestroyPlayer(GameObject gameObject, bool isDead)
    {
        if (isDead == true)
        {
            Color32 redColor = new Color32(224, 0, 0, 255);
            GameManager.Instance.PlayerListManager.ChangeColorHighscoreItem(gameObject.name, redColor);
            GameManager.Instance.UIManager.PopupMessageItemManager.InstantiateItem(gameObject.name, ItemType.Death);
            DictionaryGameObjectsLosers.Add(gameObject.name, "DNF");
        }
        else
        {
            Color32 greenColor = new Color32(87, 224, 0, 255);
            GameManager.Instance.PlayerListManager.ChangeColorHighscoreItem(gameObject.name, greenColor);
            GameManager.Instance.UIManager.PopupMessageItemManager.InstantiateItem(gameObject.name, ItemType.Winning);

            string time = GameManager.Instance.UIManager.Timer.GetTime();
            GameManager.Instance.UIManager.HighscoreManager.InstantiateItem(gameObject.name + " - " + time);
            DictionaryGameObjectsWinners.Add(gameObject.name, time);
        }

        ListGameObjectsPlayers.Remove(gameObject);
        SetTextPlayersCounter();

        Destroy(gameObject);

        CheckAllPlayersAreDeadAndActivateTheGameOver();
    }

    private void CheckAllPlayersAreDeadAndActivateTheGameOver()
    {
        if (ListGameObjectsPlayers.Count == 0)
        {
            GameManager.Instance.GameOver();       
        }
    }

    public string GetWinnerName()
    {
        if (DictionaryGameObjectsWinners.Count > 0)
            return DictionaryGameObjectsWinners.Keys.First();
        else
            return "";
    }


    //ZROBIC KTO PROWADZI???
    //public void LateUpdate()
    //{
    //    ShowDistanceToFinish();
    //}

    //float nearestPlayer = float.MaxValue;
    //private void ShowDistanceToFinish()
    //{
    //    if (ListGameObjectsPlayers != null)
    //    {
    //        foreach (var gameObject in ListGameObjectsPlayers)
    //        {
    //            var tempDistance = gameObject.GetComponent<Player>().GetDistanceToDestiantionPosition();
    //            if (tempDistance < nearestPlayer)
    //            {
    //                nearestPlayer = tempDistance;
    //                Debug.Log("WYGRYWA: " + gameObject.name + " " + tempDistance);

    //                GameManager.Instance.UIManager.HighscoreManager.SetFirstOnHighscore(gameObject.name);
    //            }
    //        }

    //        Debug.DrawLine(gameObject.transform.position, _destinationPosition.position, Color.red);
    //    }
    //}
}
