using System.Collections.Generic;
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
    public Dictionary<GameObject, string> DictionaryGameObjectsWinners = new Dictionary<GameObject, string>();
    
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
           // GameManager.Instance.UIManager.HighscoreManager.InstantiateItem(chatPlayerMessage.User);
            SpawnNewPlayer(chatPlayerMessage.User);

            //GameManager.Instance.TwitchChat.WriteChat($"{chatPlayerMessage.User} has joined!");
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
        foreach (var item in ListGameObjectsPlayers)
        {
            item.GetComponent<Player>().Agent.isStopped = isStopped;
        }
    }

    public void SetTextPlayersCounter()
    {
        _textPlayersCounter.text = $"{ListGameObjectsPlayers.Count}/{_numberOfPlayers}";
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
