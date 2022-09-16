using System.Collections.Generic;
using UnityEngine;

public class LeaderboardListManager : ListManager
{
    [Header("Items")]
    [SerializeField] private GameObject _gameObjectGoldItem;
    [SerializeField] private GameObject _gameObjectSilverItem;
    [SerializeField] private GameObject _gameObjectBronzeItem;

    [Header("Text colors")]
    [SerializeField] private Color32 _colorGoldMedal;
    [SerializeField] private Color32 _colorSilverMedal;
    [SerializeField] private Color32 _colorBronzeMedal;
    [SerializeField] private Color32 _colorLosers;

    [Header("Icons")]
    [SerializeField] private Sprite _goldIcon;
    [SerializeField] private Sprite _silverIcon;
    [SerializeField] private Sprite _bronzeIcon;

    private void OnEnable()
    {
        SetHighscoreItem();
    }

    private void SetHighscoreItem()
    {
        var counter = 0;
        var winnersDictionary = GameManager.Instance.PlayersManager.DictionaryGameObjectsWinners;
        var losersDictionary = GameManager.Instance.PlayersManager.DictionaryGameObjectsLosers;

        foreach (KeyValuePair<string, string> item in winnersDictionary)
        {
            counter++;
            var text = ($". {item.Key} {item.Value}");
            switch (counter)
            {
                case 1:
                    InstantiateItem(text, _colorGoldMedal, _gameObjectGoldItem);
                    break;

                case 2:
                    InstantiateItem(text, _colorSilverMedal, _gameObjectSilverItem);
                    break;

                case 3:
                    InstantiateItem(text, _colorBronzeMedal, _gameObjectBronzeItem);
                    break;

                default:
                    text = ($"{counter}. {item.Key} {item.Value}");   
                    InstantiateItem(text, Color.white);
                    break;
            }
        }

        counter++;
        foreach (KeyValuePair<string, string> item in losersDictionary)
        {
            var text = ($"{counter}. {item.Key} {item.Value}");
            InstantiateItem(text, _colorLosers);
        }
    }
}
