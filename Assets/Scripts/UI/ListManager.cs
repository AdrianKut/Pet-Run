using System;
using TMPro;
using UnityEngine;

public abstract class ListManager : MonoBehaviour, IItemManager
{
    [SerializeField] private GameObject _gameObjectListItem;
    [SerializeField] private GameObject _contentListParent;

    public void InstantiateItem(string text, Color color, GameObject gameObject = null)
    {
        if (gameObject == null)
        {
            gameObject = _gameObjectListItem;
        }

        var item = Instantiate(gameObject);
        item.transform.SetParent(_contentListParent.transform);
        item.name = text;

        var itemText = item.GetComponent<TextMeshProUGUI>();
        itemText.text = text;
        itemText.color = color;
    }

    public void ChangeColorHighscoreItem(string nameOfGameObject, Color color)
    {
        for (int i = 0; i < _contentListParent.transform.childCount; i++)
        {
            var player = _contentListParent.transform.GetChild(i);
            if (player.name.Contains(nameOfGameObject))
            {
                player.GetComponent<TextMeshProUGUI>().color = color;
                break;
            }
        }
    }
}