using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderboardManager : PlayerListManager
{
    private void OnEnable()
    {
        SetHighscoreItem();
    }

    private void SetHighscoreItem()
    {
        var counter = 1;
        var winnersDictionary = GameManager.Instance.PlayersManager.DictionaryGameObjectsWinners;
        var losersDictionary = GameManager.Instance.PlayersManager.DictionaryGameObjectsLosers;

        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.AddRange(winnersDictionary.Where(x => x.Value == "DNF"));

        foreach (KeyValuePair<string, string> item in winnersDictionary)
        {
            Color color;
            switch (counter)
            {
                //TODO MEDALE NA KAZDE MIEJSCA ITP w
                case 1:
                    color = Color.yellow;
                    break;

                case 2:
                    color = Color.green;
                    break;

                case 3:
                    color = Color.blue;
                    break;

                default:
                    color = Color.white;
                    break;
            }

            var text = ($"{counter++}. {item.Key} - {item.Value}");
            InstantiateItem(text, color);
        }

        foreach (KeyValuePair<string, string> item in losersDictionary)
        {
            var text = ($"{item.Key} - {item.Value}");
            InstantiateItem(text, Color.white);
        }
    }
}
