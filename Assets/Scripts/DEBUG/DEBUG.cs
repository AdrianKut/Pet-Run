using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public int numberOfDebugersPlayers = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            for (int i = 0; i < numberOfDebugersPlayers; i++)
            {
                var chatPlayerMessage = new ChatPlayerMessage("debuger00"+i,"!j");
                GameManager.Instance.PlayersManager.JoinPlayerToTheGame(chatPlayerMessage);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.Instance.UIManager.PopupMessageItemManager.InstantiateItem("WNNER", ItemType.Winning);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameManager.Instance.UIManager.PopupMessageItemManager.InstantiateItem("NEW PLAYER", ItemType.NewPlayer);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.UIManager.PopupMessageItemManager.InstantiateItem("DEAD", ItemType.Death);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var tempGameObject = FindObjectOfType<Player>();
            GameManager.Instance.PlayersManager.DestroyPlayer(tempGameObject.gameObject, true);
        }
    }

}
