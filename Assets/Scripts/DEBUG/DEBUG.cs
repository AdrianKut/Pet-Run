

using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DEBUG : MonoBehaviour
{
    public int numberOfDebugersPlayers = 1;

    public static string GenerateName(int len)
    {       
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[Random.Range(0,consonants.Length)].ToUpper();
        Name += vowels[Random.Range(0,vowels.Length)];
        int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        if (len >= 20)
            len = 20;

        while (b < len)
        {
            Name += consonants[Random.Range(0,consonants.Length)];
            b++;
            Name += vowels[Random.Range(0,vowels.Length)];
            b++;
        }

        return Name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            for (int i = 0; i < numberOfDebugersPlayers; i++)
            {
                var chatPlayerMessage = new ChatPlayerMessage(GenerateName(i)+i,"!j");
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

}
